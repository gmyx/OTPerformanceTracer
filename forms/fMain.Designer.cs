namespace OT_Performance_Tracer
{
    partial class fMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadFolderToolStripMenuItem = new ToolStripMenuItem();
            loadThreadLogToolStripMenuItem = new ToolStripMenuItem();
            filterToolStripMenuItem = new ToolStripMenuItem();
            showFiltersToolStripMenuItem = new ToolStripMenuItem();
            openThreadLogDialog = new OpenFileDialog();
            splitContainer1 = new SplitContainer();
            tvBlocks = new TreeView();
            cStats = new Button();
            lstLines = new ListView();
            chDateTime = new ColumnHeader();
            chData = new ColumnHeader();
            mLstContext = new ContextMenuStrip(components);
            addToFiltersToolStripMenuItem = new ToolStripMenuItem();
            openInWindowToolStripMenuItem = new ToolStripMenuItem();
            ssData = new StatusStrip();
            sslNodeID = new ToolStripStatusLabel();
            sslFunc = new ToolStripStatusLabel();
            sslAction = new ToolStripStatusLabel();
            sslObjID = new ToolStripStatusLabel();
            sslPerformer = new ToolStripStatusLabel();
            sslRuntime = new ToolStripStatusLabel();
            ssGap = new ToolStripStatusLabel();
            ssProgress = new ToolStripProgressBar();
            folderLogBrowserDialog = new FolderBrowserDialog();
            mMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            mLstContext.SuspendLayout();
            ssData.SuspendLayout();
            SuspendLayout();
            // 
            // mMenu
            // 
            mMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, filterToolStripMenuItem });
            mMenu.Location = new Point(0, 0);
            mMenu.Name = "mMenu";
            mMenu.Size = new Size(1129, 24);
            mMenu.TabIndex = 1;
            mMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadFolderToolStripMenuItem, loadThreadLogToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // loadFolderToolStripMenuItem
            // 
            loadFolderToolStripMenuItem.Name = "loadFolderToolStripMenuItem";
            loadFolderToolStripMenuItem.Size = new Size(158, 22);
            loadFolderToolStripMenuItem.Text = "Load Folder";
            loadFolderToolStripMenuItem.Click += loadFolderToolStripMenuItem_Click;
            // 
            // loadThreadLogToolStripMenuItem
            // 
            loadThreadLogToolStripMenuItem.Name = "loadThreadLogToolStripMenuItem";
            loadThreadLogToolStripMenuItem.Size = new Size(158, 22);
            loadThreadLogToolStripMenuItem.Text = "Load Single Log";
            loadThreadLogToolStripMenuItem.Click += loadThreadLogToolStripMenuItem_Click;
            // 
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showFiltersToolStripMenuItem });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            filterToolStripMenuItem.Size = new Size(45, 20);
            filterToolStripMenuItem.Text = "Filter";
            // 
            // showFiltersToolStripMenuItem
            // 
            showFiltersToolStripMenuItem.Name = "showFiltersToolStripMenuItem";
            showFiltersToolStripMenuItem.Size = new Size(137, 22);
            showFiltersToolStripMenuItem.Text = "Show Filters";
            showFiltersToolStripMenuItem.Click += showFiltersToolStripMenuItem_Click;
            // 
            // openThreadLogDialog
            // 
            openThreadLogDialog.DefaultExt = "out";
            openThreadLogDialog.Filter = "OUT Files|*.out|All files|*.*";
            openThreadLogDialog.ReadOnlyChecked = true;
            openThreadLogDialog.SelectReadOnly = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tvBlocks);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(cStats);
            splitContainer1.Panel2.Controls.Add(lstLines);
            splitContainer1.Size = new Size(1129, 584);
            splitContainer1.SplitterDistance = 376;
            splitContainer1.TabIndex = 2;
            // 
            // tvBlocks
            // 
            tvBlocks.Dock = DockStyle.Fill;
            tvBlocks.HideSelection = false;
            tvBlocks.Location = new Point(0, 0);
            tvBlocks.Name = "tvBlocks";
            tvBlocks.Size = new Size(376, 584);
            tvBlocks.TabIndex = 1;
            tvBlocks.AfterSelect += tvBlocks_AfterSelect;
            // 
            // cStats
            // 
            cStats.Enabled = false;
            cStats.Location = new Point(687, 2);
            cStats.Name = "cStats";
            cStats.Size = new Size(50, 23);
            cStats.TabIndex = 5;
            cStats.Text = "Stats";
            cStats.UseVisualStyleBackColor = true;
            cStats.Click += btnStats_Click;
            // 
            // lstLines
            // 
            lstLines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstLines.Columns.AddRange(new ColumnHeader[] { chDateTime, chData });
            lstLines.ContextMenuStrip = mLstContext;
            lstLines.FullRowSelect = true;
            lstLines.Location = new Point(0, 32);
            lstLines.Name = "lstLines";
            lstLines.Size = new Size(749, 527);
            lstLines.TabIndex = 0;
            lstLines.UseCompatibleStateImageBehavior = false;
            lstLines.View = View.Details;
            lstLines.DoubleClick += lstLines_DoubleClick;
            lstLines.KeyUp += lstLines_KeyUp;
            // 
            // chDateTime
            // 
            chDateTime.Text = "Date / time";
            chDateTime.Width = 150;
            // 
            // chData
            // 
            chData.Text = "Data";
            chData.Width = 400;
            // 
            // mLstContext
            // 
            mLstContext.Items.AddRange(new ToolStripItem[] { addToFiltersToolStripMenuItem, openInWindowToolStripMenuItem });
            mLstContext.Name = "mLstContext";
            mLstContext.Size = new Size(164, 48);
            mLstContext.Opening += mLstContext_Opening;
            // 
            // addToFiltersToolStripMenuItem
            // 
            addToFiltersToolStripMenuItem.Name = "addToFiltersToolStripMenuItem";
            addToFiltersToolStripMenuItem.Size = new Size(163, 22);
            addToFiltersToolStripMenuItem.Text = "Add to Filters";
            addToFiltersToolStripMenuItem.Click += addToFiltersToolStripMenuItem_Click;
            // 
            // openInWindowToolStripMenuItem
            // 
            openInWindowToolStripMenuItem.Name = "openInWindowToolStripMenuItem";
            openInWindowToolStripMenuItem.Size = new Size(163, 22);
            openInWindowToolStripMenuItem.Text = "Open in Window";
            openInWindowToolStripMenuItem.Click += openInWindowToolStripMenuItem_Click;
            // 
            // ssData
            // 
            ssData.Items.AddRange(new ToolStripItem[] { sslNodeID, sslFunc, sslAction, sslObjID, sslPerformer, sslRuntime, ssGap, ssProgress });
            ssData.Location = new Point(0, 586);
            ssData.Name = "ssData";
            ssData.Size = new Size(1129, 22);
            ssData.TabIndex = 3;
            ssData.Text = "statusStrip1";
            // 
            // sslNodeID
            // 
            sslNodeID.Name = "sslNodeID";
            sslNodeID.Size = new Size(0, 17);
            // 
            // sslFunc
            // 
            sslFunc.Name = "sslFunc";
            sslFunc.Size = new Size(0, 17);
            // 
            // sslAction
            // 
            sslAction.Name = "sslAction";
            sslAction.Size = new Size(0, 17);
            // 
            // sslObjID
            // 
            sslObjID.Name = "sslObjID";
            sslObjID.Size = new Size(0, 17);
            // 
            // sslPerformer
            // 
            sslPerformer.Name = "sslPerformer";
            sslPerformer.Size = new Size(0, 17);
            // 
            // sslRuntime
            // 
            sslRuntime.Name = "sslRuntime";
            sslRuntime.Size = new Size(13, 17);
            sslRuntime.Text = "0";
            // 
            // ssGap
            // 
            ssGap.Name = "ssGap";
            ssGap.Size = new Size(1101, 17);
            ssGap.Spring = true;
            // 
            // ssProgress
            // 
            ssProgress.Name = "ssProgress";
            ssProgress.Size = new Size(100, 16);
            ssProgress.Visible = false;
            // 
            // folderLogBrowserDialog
            // 
            folderLogBrowserDialog.ShowNewFolderButton = false;
            // 
            // fMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 608);
            Controls.Add(ssData);
            Controls.Add(splitContainer1);
            Controls.Add(mMenu);
            MainMenuStrip = mMenu;
            Name = "fMain";
            Text = "OT Performance Tracer";
            mMenu.ResumeLayout(false);
            mMenu.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            mLstContext.ResumeLayout(false);
            ssData.ResumeLayout(false);
            ssData.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip mMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadThreadLogToolStripMenuItem;
        private OpenFileDialog openThreadLogDialog;
        private SplitContainer splitContainer1;
        private ListView lstLines;
        private TreeView tvBlocks;
        private ColumnHeader chDateTime;
        private ColumnHeader chData;
        private Button cStats;
        private StatusStrip ssData;
        private ToolStripStatusLabel sslNodeID;
        private ToolStripStatusLabel sslFunc;
        private ToolStripStatusLabel sslAction;
        private ToolStripStatusLabel sslObjID;
        private ToolStripStatusLabel sslPerformer;
        private ToolStripStatusLabel sslRuntime;
        private ToolStripMenuItem filterToolStripMenuItem;
        private ToolStripMenuItem showFiltersToolStripMenuItem;
        private ToolStripMenuItem loadFolderToolStripMenuItem;
        private FolderBrowserDialog folderLogBrowserDialog;
        private ContextMenuStrip mLstContext;
        private ToolStripMenuItem addToFiltersToolStripMenuItem;
        private ToolStripProgressBar ssProgress;
        private ToolStripStatusLabel ssGap;
        private ToolStripMenuItem openInWindowToolStripMenuItem;
    }
}
