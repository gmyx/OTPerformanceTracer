using System;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace OT_Performance_Tracer
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private Dictionary<string, ThreadBlocks> Blocks = [];

        private void LoadSingleFile(string path, TreeNode rootNode, IProgress<(string, TreeNode[], int)> progress)
        {
            ThreadLogAnalyser lThread = new ThreadLogAnalyser(path);
            if (lThread.LoadFile()) lThread.AnalyseFile();

            Dictionary<int, ThreadBlocks> singleThreadBlocks = lThread.Blocks;
            string FileName = Path.GetFileNameWithoutExtension(path);
            //TreeNode fileNode = tvBlocks.Nodes.Add(FileName, FileName);
            TreeNode[] parts = [];

            //now show each block in the tree
            Dictionary<string, ThreadBlocks> tempBlocks = [];
            int redCount = 0;
            foreach (KeyValuePair<int, ThreadBlocks> block in singleThreadBlocks)
            {
                DateTime startTime = block.Value.Parts!.First().timeStamp;
                DateTime endTime = block.Value.Parts!.Last().timeStamp;
                var diff = endTime - startTime;

                TreeNode singlePart = new();
                singlePart.Text = $"{ThreadBlocks.BlockNames[block.Value.BlockType]} [{diff}]";
                singlePart.Name = $"{FileName}_{block.Key}";
                //set text color red if more than 10 seconds, unless startup, since that is very long
                if (diff.TotalSeconds > 10 && block.Value.BlockType != ThreadBlocks.BlockTypes.Startup)
                {
                    singlePart.ForeColor = Color.Red;
                    redCount++;
                }

                parts = [.. parts, singlePart];

                tempBlocks.Add($"{FileName}_{block.Key}", block.Value);
            }

            lock (Blocks)
            {
                foreach (KeyValuePair<string, ThreadBlocks> singleBlock in tempBlocks)
                {
                    Blocks.Add(singleBlock.Key, singleBlock.Value);
                }
            }

            progress.Report((FileName, parts, redCount));
        }

        private void loadThreadLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open thread log dialog
            if (openThreadLogDialog.ShowDialog() != DialogResult.OK) return;

            var progress = new Progress<(string, TreeNode[], int)>(value =>
            {
                //update tree node
                UpdateTreeNode(value.Item1, value.Item2, value.Item3);
            });
            string FileName = Path.GetFileNameWithoutExtension(openThreadLogDialog.FileName);

            //create node
            TreeNode fileNode = tvBlocks.Nodes.Add(FileName, FileName);

            _ = Task.Factory.StartNew(() => LoadSingleFile(openThreadLogDialog.FileName, fileNode!, progress), TaskCreationOptions.LongRunning);
        }

        private void tvBlocks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //change the list view to show the block            
            string blockName = e.Node!.Name;

            //see if file or block, if file abort
            if (blockName.Contains("_") == false) return;

            //get the block
            int blockIndex = int.Parse(blockName.Split("_")[1]);
            ThreadBlocks? singleBlock;
            if (Blocks.TryGetValue(blockName, out singleBlock) == false) return; //something went wrong

            //update screen data
            sslNodeID.Text = blockName;

            //update data fields
            sslFunc.Text = singleBlock.Func;
            sslAction.Text = singleBlock.Action;
            sslObjID.Text = singleBlock.objID;
            sslPerformer.Text = singleBlock.Performer;

            DateTime startTime = singleBlock.Parts!.First().timeStamp;
            DateTime endTime = singleBlock.Parts!.Last().timeStamp;
            var diff = endTime - startTime;
            sslRuntime.Text = diff.ToString();

            //load the list
            lstLines.SuspendLayout(); //many writes, so don't update with every add
            lstLines.Items.Clear();

            DateTime diffFromPrevious = singleBlock.Parts![0].timeStamp;
            foreach ((DateTime timeStamp, string message) part in singleBlock.Parts!)
            {
                //see if excluded
                if (LogFilters.getRegistrySettings().Any(part.message.Contains)) continue;

                ListViewItem singleLine = new(part.timeStamp.ToString());
                singleLine.SubItems.Add(part.message);

                //mark red if more than 10 seconds have passed
                if ((part.timeStamp - diffFromPrevious).TotalSeconds > 10 ) singleLine.ForeColor = Color.Red;
                diffFromPrevious = part.timeStamp;
                lstLines.Items.Add(singleLine);
            }

            //finish up
            lstLines.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstLines.ResumeLayout();
        }

        private void UpdateTreeNode(string nodeName, TreeNode[] subNodes, int redCount)
        {
            //get the right parent
            TreeNode? root = tvBlocks.Nodes[nodeName];

            if (root == null) return;
            root.Nodes.AddRange(subNodes);

            //update node text
            root.Text = root.Text + $"[{redCount}]";
        }

        private void loadFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderLogBrowserDialog.ShowDialog() != DialogResult.OK) return;

            //clear out the tree and list views
            tvBlocks.Nodes.Clear();
            lstLines.Items.Clear();
            Blocks.Clear();

            //for each file in the folder, try to load it
            string[] files = Directory.GetFiles(folderLogBrowserDialog.SelectedPath);

            //prepare status bar
            ssProgress.Visible = true;
            ssProgress.Value = 0;

            int max = files.Length;
            int current = 0;

            var progress = new Progress<(string, TreeNode[], int)>(value =>
            {
                current++;
                float per = ((float)current / (float)max) * 100;
                ssProgress.Value = (int)Math.Floor(per);

                //update the tree node
                UpdateTreeNode(value.Item1, value.Item2, value.Item3);

                if (current >= max) ssProgress.Visible = false;
            });

            //Thread[] threads = [];
            tvBlocks.SuspendLayout();
            foreach (string file in files)
            {
                //create the parent node
                string FileName = Path.GetFileNameWithoutExtension(file);
                TreeNode fileNode = tvBlocks.Nodes.Add(FileName, FileName);
            }
            tvBlocks.ResumeLayout();
            tvBlocks.PerformLayout();

            Thread.Sleep(1000); //allow form to catch up

            foreach (string file in files)
            {
                string FileName = Path.GetFileNameWithoutExtension(file);
                TreeNode? fileNode = tvBlocks.Nodes[FileName];
                _ = Task.Factory.StartNew(() => LoadSingleFile(file, fileNode!, progress), TaskCreationOptions.LongRunning);
            }
        }

        private void showFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fFilters f = new();

            f.ShowDialog();
        }

        private void addToFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAddEditFilter form = new();
            if(form.Add(lstLines.SelectedItems[0].SubItems[1].Text) == DialogResult.Cancel) return;

            //add the filter and save
            LogFilters.addFilter(form.FilterValue);

            //reload screen
        }

        private void mLstContext_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            addToFiltersToolStripMenuItem.Enabled = (lstLines.SelectedItems.Count==0 ? false : true);
        }
    }
}
