using OT_Performance_Tracer.classes;

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
            string[] filters = LogFilters.getRegistrySettings(LogFilters.FilterTypes.ThreadFilter);
            foreach (KeyValuePair<int, ThreadBlocks> block in singleThreadBlocks)
            {
                //see if its in the filtered list
                if (block.Value.Func != null) //we wil not filter nulls
                {
                    if (filters.Any(item => block.Value.Func!.Contains(item))) continue;
                }
                DateTime startTime = block.Value.Parts!.First().timeStamp;
                DateTime endTime = block.Value.Parts!.Last().timeStamp;
                var diff = endTime - startTime;

                TreeNode singlePart = new();
                string displayFunc = block.Value.Func!;
                if (displayFunc == "ll")
                {
                    //append action, to get a bit more details, use ::
                    displayFunc = $"{displayFunc}::{block.Value.Action}";
                }
                singlePart.Text = $"{ThreadBlocks.BlockNames[block.Value.BlockType]} [{diff}] [{displayFunc}]";
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

            //add this block to the list. need to lock access to avoid thread races
            lock (Blocks)
            {
                foreach (KeyValuePair<string, ThreadBlocks> singleBlock in tempBlocks)
                {
                    Blocks.Add(singleBlock.Key, singleBlock.Value);
                }
            }

            //update screen, using a lock to avid conflicts
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

            //if there are stats, enable button
            cStats.Enabled = (singleBlock.stats != null);

            //load the list
            lstLines.SuspendLayout(); //many writes, so don't update with every add
            lstLines.Items.Clear();

            DateTime diffFromPrevious = singleBlock.Parts![0].timeStamp;
            foreach ((DateTime timeStamp, string level, string message) part in singleBlock.Parts!)
            {
                //see if excluded
                if (LogFilters.getRegistrySettings(LogFilters.FilterTypes.Logfilter).Any(part.message.Contains)) continue;

                ListViewItem singleLine = new(part.timeStamp.ToString());
                singleLine.SubItems.Add(part.level);
                singleLine.SubItems.Add(part.message);

                //mark red if more than 10 seconds have passed
                if ((part.timeStamp - diffFromPrevious).TotalSeconds > 10) singleLine.ForeColor = Color.Red;
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

            f.ShowList(LogFilters.FilterTypes.Logfilter);
        }

        private void addToFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doAddToLogFilter();
        }

        private void mLstContext_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            addToFiltersToolStripMenuItem.Enabled = (lstLines.SelectedItems.Count == 0 ? false : true);
            openInWindowToolStripMenuItem.Enabled = (lstLines.SelectedItems.Count == 0 ? false : true);
        }

        private void openInWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //shunt to common function
            openShowDetails();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            if (tvBlocks.SelectedNode == null) return;

            string blockName = tvBlocks.SelectedNode!.Name;

            //see if file or block, if file abort
            if (blockName.Contains("_") == false) return;

            //get the block
            int blockIndex = int.Parse(blockName.Split("_")[1]);
            ThreadBlocks? singleBlock;
            if (Blocks.TryGetValue(blockName, out singleBlock) == false) return; //something went wrong

            fShowDetails form = new();
            form.ShowDetails(singleBlock.stats!);
        }

        private void lstLines_DoubleClick(object sender, EventArgs e)
        {
            //shunt to common function
            openShowDetails();
        }

        private void openShowDetails()
        {
            if (lstLines.SelectedItems.Count == 0) return;

            fShowDetails form = new();

            form.ShowDetails(lstLines.SelectedItems[0].SubItems[2].Text);
        }

        private void lstLines_KeyUp(object sender, KeyEventArgs e)
        {
            //if key is enter, with no modifyers, open selected item
            if (e.Alt == true || e.Control == true || e.Shift == true) return;
            if (e.KeyCode != Keys.Enter) return;

            //shunt to common function
            openShowDetails();
        }

        private void doAddToLogFilter()
        {
            fAddEditFilter form = new();
            if (form.Add(lstLines.SelectedItems[0].SubItems[2].Text) == DialogResult.Cancel) return;

            //add the filter and save
            LogFilters.addFilter(form.FilterValue, LogFilters.FilterTypes.Logfilter);

            //reload screen
        }

        private void doAddToThreadFilter()
        {
            if (tvBlocks.SelectedNode == null) return;

            //get the block
            int blockIndex = int.Parse(tvBlocks.SelectedNode.Name.Split("_")[1]);
            ThreadBlocks? singleBlock;
            if (Blocks.TryGetValue(tvBlocks.SelectedNode.Name, out singleBlock) == false) return; //something went wrong

            fAddEditFilter form = new();
            if (form.Add(singleBlock.Func!) == DialogResult.Cancel) return;

            //add the filter and save
            LogFilters.addFilter(form.FilterValue, LogFilters.FilterTypes.ThreadFilter);

            //reload - missing
        }

        private void mTVContext_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            addToFiltersTVToolStripMenuItem.Enabled = (tvBlocks.SelectedNode == null ? false : true);
        }

        private void addSelectedToFilterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            doAddToThreadFilter();
        }

        private void addToFiltersTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doAddToThreadFilter();
        }

        private void showFiltersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fFilters f = new();

            f.ShowList(LogFilters.FilterTypes.ThreadFilter);
        }
    }
}