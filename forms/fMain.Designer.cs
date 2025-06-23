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
            toolStripSeparator1 = new ToolStripSeparator();
            recentFolderMenuItem = new ToolStripMenuItem();
            recentFolderSampleItem = new ToolStripMenuItem();
            recentFilesMenuItem = new ToolStripMenuItem();
            recentFileSampleItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            singleThreadToolStripMenuItem = new ToolStripMenuItem();
            singleFileToolStripMenuItem = new ToolStripMenuItem();
            allOpenedFilesToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            filterToolStripMenuItem = new ToolStripMenuItem();
            logViewFiltersToolStripMenuItem = new ToolStripMenuItem();
            showFiltersToolStripMenuItem = new ToolStripMenuItem();
            addSelectedToFilterToolStripMenuItem = new ToolStripMenuItem();
            threadListFiltersToolStripMenuItem = new ToolStripMenuItem();
            showFiltersToolStripMenuItem1 = new ToolStripMenuItem();
            addSelectedToFilterToolStripMenuItem1 = new ToolStripMenuItem();
            highLigthToolStripMenuItem = new ToolStripMenuItem();
            openThreadLogDialog = new OpenFileDialog();
            splitContainer1 = new SplitContainer();
            tvBlocks = new TreeView();
            mTVContext = new ContextMenuStrip(components);
            addToFiltersTVToolStripMenuItem = new ToolStripMenuItem();
            cStats = new Button();
            lstLines = new ListView();
            chDateTime = new ColumnHeader();
            chLevel = new ColumnHeader();
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
            mTVContext.SuspendLayout();
            mLstContext.SuspendLayout();
            ssData.SuspendLayout();
            SuspendLayout();
            // 
            // mMenu
            // 
            mMenu.ImageScalingSize = new Size(36, 36);
            mMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolStripMenuItem1, settingsToolStripMenuItem });
            mMenu.Location = new Point(0, 0);
            mMenu.Name = "mMenu";
            mMenu.Padding = new Padding(13, 5, 0, 5);
            mMenu.Size = new Size(2419, 51);
            mMenu.TabIndex = 1;
            mMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadFolderToolStripMenuItem, loadThreadLogToolStripMenuItem, toolStripSeparator1, recentFolderMenuItem, recentFilesMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(80, 41);
            fileToolStripMenuItem.Text = "&File";
            // 
            // loadFolderToolStripMenuItem
            // 
            loadFolderToolStripMenuItem.Name = "loadFolderToolStripMenuItem";
            loadFolderToolStripMenuItem.Size = new Size(358, 48);
            loadFolderToolStripMenuItem.Text = "Load Folder";
            loadFolderToolStripMenuItem.Click += loadFolderToolStripMenuItem_Click;
            // 
            // loadThreadLogToolStripMenuItem
            // 
            loadThreadLogToolStripMenuItem.Name = "loadThreadLogToolStripMenuItem";
            loadThreadLogToolStripMenuItem.Size = new Size(358, 48);
            loadThreadLogToolStripMenuItem.Text = "Load Single Log";
            loadThreadLogToolStripMenuItem.Click += loadThreadLogToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(355, 6);
            // 
            // recentFolderMenuItem
            // 
            recentFolderMenuItem.DropDownItems.AddRange(new ToolStripItem[] { recentFolderSampleItem });
            recentFolderMenuItem.Name = "recentFolderMenuItem";
            recentFolderMenuItem.Size = new Size(358, 48);
            recentFolderMenuItem.Text = "Recent Folder";
            // 
            // recentFolderSampleItem
            // 
            recentFolderSampleItem.Enabled = false;
            recentFolderSampleItem.Name = "recentFolderSampleItem";
            recentFolderSampleItem.Size = new Size(232, 48);
            recentFolderSampleItem.Text = "None";
            // 
            // recentFilesMenuItem
            // 
            recentFilesMenuItem.DropDownItems.AddRange(new ToolStripItem[] { recentFileSampleItem });
            recentFilesMenuItem.Name = "recentFilesMenuItem";
            recentFilesMenuItem.Size = new Size(358, 48);
            recentFilesMenuItem.Text = "Recent Files";
            // 
            // recentFileSampleItem
            // 
            recentFileSampleItem.Enabled = false;
            recentFileSampleItem.Name = "recentFileSampleItem";
            recentFileSampleItem.Size = new Size(232, 48);
            recentFileSampleItem.Text = "None";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { singleThreadToolStripMenuItem, singleFileToolStripMenuItem, allOpenedFilesToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(117, 41);
            toolStripMenuItem1.Text = "Search";
            // 
            // singleThreadToolStripMenuItem
            // 
            singleThreadToolStripMenuItem.Name = "singleThreadToolStripMenuItem";
            singleThreadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            singleThreadToolStripMenuItem.Size = new Size(419, 48);
            singleThreadToolStripMenuItem.Text = "Single Thread";
            singleThreadToolStripMenuItem.Click += singleThreadToolStripMenuItem_Click;
            // 
            // singleFileToolStripMenuItem
            // 
            singleFileToolStripMenuItem.Name = "singleFileToolStripMenuItem";
            singleFileToolStripMenuItem.Size = new Size(419, 48);
            singleFileToolStripMenuItem.Text = "Single File";
            // 
            // allOpenedFilesToolStripMenuItem
            // 
            allOpenedFilesToolStripMenuItem.Name = "allOpenedFilesToolStripMenuItem";
            allOpenedFilesToolStripMenuItem.Size = new Size(419, 48);
            allOpenedFilesToolStripMenuItem.Text = "All Opened Files";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filterToolStripMenuItem, highLigthToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(134, 41);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logViewFiltersToolStripMenuItem, threadListFiltersToolStripMenuItem });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            filterToolStripMenuItem.Size = new Size(289, 48);
            filterToolStripMenuItem.Text = "Filter";
            // 
            // logViewFiltersToolStripMenuItem
            // 
            logViewFiltersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showFiltersToolStripMenuItem, addSelectedToFilterToolStripMenuItem });
            logViewFiltersToolStripMenuItem.Name = "logViewFiltersToolStripMenuItem";
            logViewFiltersToolStripMenuItem.Size = new Size(373, 48);
            logViewFiltersToolStripMenuItem.Text = "Log View Filters";
            // 
            // showFiltersToolStripMenuItem
            // 
            showFiltersToolStripMenuItem.Name = "showFiltersToolStripMenuItem";
            showFiltersToolStripMenuItem.Size = new Size(421, 48);
            showFiltersToolStripMenuItem.Text = "Show Filters";
            // 
            // addSelectedToFilterToolStripMenuItem
            // 
            addSelectedToFilterToolStripMenuItem.Name = "addSelectedToFilterToolStripMenuItem";
            addSelectedToFilterToolStripMenuItem.Size = new Size(421, 48);
            addSelectedToFilterToolStripMenuItem.Text = "Add Selected to Filter";
            // 
            // threadListFiltersToolStripMenuItem
            // 
            threadListFiltersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showFiltersToolStripMenuItem1, addSelectedToFilterToolStripMenuItem1 });
            threadListFiltersToolStripMenuItem.Name = "threadListFiltersToolStripMenuItem";
            threadListFiltersToolStripMenuItem.Size = new Size(373, 48);
            threadListFiltersToolStripMenuItem.Text = "Thread List Filters";
            // 
            // showFiltersToolStripMenuItem1
            // 
            showFiltersToolStripMenuItem1.Name = "showFiltersToolStripMenuItem1";
            showFiltersToolStripMenuItem1.Size = new Size(421, 48);
            showFiltersToolStripMenuItem1.Text = "Show Filters";
            // 
            // addSelectedToFilterToolStripMenuItem1
            // 
            addSelectedToFilterToolStripMenuItem1.Name = "addSelectedToFilterToolStripMenuItem1";
            addSelectedToFilterToolStripMenuItem1.Size = new Size(421, 48);
            addSelectedToFilterToolStripMenuItem1.Text = "Add Selected to Filter";
            // 
            // highLigthToolStripMenuItem
            // 
            highLigthToolStripMenuItem.Name = "highLigthToolStripMenuItem";
            highLigthToolStripMenuItem.Size = new Size(289, 48);
            highLigthToolStripMenuItem.Text = "Highlights";
            highLigthToolStripMenuItem.Click += highLigthToolStripMenuItem_Click;
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
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 59);
            splitContainer1.Margin = new Padding(6, 7, 6, 7);
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
            splitContainer1.Size = new Size(2419, 1379);
            splitContainer1.SplitterDistance = 803;
            splitContainer1.SplitterWidth = 9;
            splitContainer1.TabIndex = 2;
            // 
            // tvBlocks
            // 
            tvBlocks.ContextMenuStrip = mTVContext;
            tvBlocks.Dock = DockStyle.Fill;
            tvBlocks.HideSelection = false;
            tvBlocks.Location = new Point(0, 0);
            tvBlocks.Margin = new Padding(6, 7, 6, 7);
            tvBlocks.Name = "tvBlocks";
            tvBlocks.Size = new Size(803, 1379);
            tvBlocks.TabIndex = 1;
            tvBlocks.AfterSelect += tvBlocks_AfterSelect;
            // 
            // mTVContext
            // 
            mTVContext.ImageScalingSize = new Size(36, 36);
            mTVContext.Items.AddRange(new ToolStripItem[] { addToFiltersTVToolStripMenuItem });
            mTVContext.Name = "mLstContext";
            mTVContext.Size = new Size(253, 48);
            mTVContext.Opening += mTVContext_Opening;
            // 
            // addToFiltersTVToolStripMenuItem
            // 
            addToFiltersTVToolStripMenuItem.Name = "addToFiltersTVToolStripMenuItem";
            addToFiltersTVToolStripMenuItem.Size = new Size(252, 44);
            addToFiltersTVToolStripMenuItem.Text = "Add to Filters";
            addToFiltersTVToolStripMenuItem.Click += addToFiltersTVToolStripMenuItem_Click;
            // 
            // cStats
            // 
            cStats.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cStats.Enabled = false;
            cStats.Location = new Point(1472, 5);
            cStats.Margin = new Padding(6, 7, 6, 7);
            cStats.Name = "cStats";
            cStats.Size = new Size(107, 57);
            cStats.TabIndex = 5;
            cStats.Text = "Stats";
            cStats.UseVisualStyleBackColor = true;
            cStats.Click += btnStats_Click;
            // 
            // lstLines
            // 
            lstLines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstLines.Columns.AddRange(new ColumnHeader[] { chDateTime, chLevel, chData });
            lstLines.ContextMenuStrip = mLstContext;
            lstLines.FullRowSelect = true;
            lstLines.Location = new Point(0, 79);
            lstLines.Margin = new Padding(6, 7, 6, 7);
            lstLines.Name = "lstLines";
            lstLines.Size = new Size(1596, 1294);
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
            // chLevel
            // 
            chLevel.Text = "Level";
            chLevel.Width = 150;
            // 
            // chData
            // 
            chData.Text = "Data";
            chData.Width = 500;
            // 
            // mLstContext
            // 
            mLstContext.ImageScalingSize = new Size(36, 36);
            mLstContext.Items.AddRange(new ToolStripItem[] { addToFiltersToolStripMenuItem, openInWindowToolStripMenuItem });
            mLstContext.Name = "mLstContext";
            mLstContext.Size = new Size(295, 92);
            mLstContext.Opening += mLstContext_Opening;
            // 
            // addToFiltersToolStripMenuItem
            // 
            addToFiltersToolStripMenuItem.Name = "addToFiltersToolStripMenuItem";
            addToFiltersToolStripMenuItem.Size = new Size(294, 44);
            addToFiltersToolStripMenuItem.Text = "Add to Filters";
            addToFiltersToolStripMenuItem.Click += addToFiltersToolStripMenuItem_Click;
            // 
            // openInWindowToolStripMenuItem
            // 
            openInWindowToolStripMenuItem.Name = "openInWindowToolStripMenuItem";
            openInWindowToolStripMenuItem.Size = new Size(294, 44);
            openInWindowToolStripMenuItem.Text = "Open in Window";
            openInWindowToolStripMenuItem.Click += openInWindowToolStripMenuItem_Click;
            // 
            // ssData
            // 
            ssData.ImageScalingSize = new Size(36, 36);
            ssData.Items.AddRange(new ToolStripItem[] { sslNodeID, sslFunc, sslAction, sslObjID, sslPerformer, sslRuntime, ssGap, ssProgress });
            ssData.Location = new Point(0, 1452);
            ssData.Name = "ssData";
            ssData.Padding = new Padding(2, 0, 30, 0);
            ssData.Size = new Size(2419, 48);
            ssData.TabIndex = 3;
            ssData.Text = "statusStrip1";
            // 
            // sslNodeID
            // 
            sslNodeID.Name = "sslNodeID";
            sslNodeID.Size = new Size(0, 37);
            // 
            // sslFunc
            // 
            sslFunc.Name = "sslFunc";
            sslFunc.Size = new Size(0, 37);
            // 
            // sslAction
            // 
            sslAction.Name = "sslAction";
            sslAction.Size = new Size(0, 37);
            // 
            // sslObjID
            // 
            sslObjID.Name = "sslObjID";
            sslObjID.Size = new Size(0, 37);
            // 
            // sslPerformer
            // 
            sslPerformer.Name = "sslPerformer";
            sslPerformer.Size = new Size(0, 37);
            // 
            // sslRuntime
            // 
            sslRuntime.Name = "sslRuntime";
            sslRuntime.Size = new Size(32, 37);
            sslRuntime.Text = "0";
            // 
            // ssGap
            // 
            ssGap.Name = "ssGap";
            ssGap.Size = new Size(2355, 37);
            ssGap.Spring = true;
            // 
            // ssProgress
            // 
            ssProgress.Name = "ssProgress";
            ssProgress.Size = new Size(214, 34);
            ssProgress.Visible = false;
            // 
            // folderLogBrowserDialog
            // 
            folderLogBrowserDialog.ShowNewFolderButton = false;
            // 
            // fMain
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2419, 1500);
            Controls.Add(ssData);
            Controls.Add(splitContainer1);
            Controls.Add(mMenu);
            MainMenuStrip = mMenu;
            Margin = new Padding(6, 7, 6, 7);
            Name = "fMain";
            Text = "OT Performance Tracer";
            mMenu.ResumeLayout(false);
            mMenu.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            mTVContext.ResumeLayout(false);
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
        private ToolStripMenuItem loadFolderToolStripMenuItem;
        private FolderBrowserDialog folderLogBrowserDialog;
        private ContextMenuStrip mLstContext;
        private ToolStripMenuItem addToFiltersToolStripMenuItem;
        private ToolStripProgressBar ssProgress;
        private ToolStripStatusLabel ssGap;
        private ToolStripMenuItem openInWindowToolStripMenuItem;
        private ColumnHeader chLevel;
        private ContextMenuStrip mTVContext;
        private ToolStripMenuItem addToFiltersTVToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem recentFolderMenuItem;
        private ToolStripMenuItem recentFolderSampleItem;
        private ToolStripMenuItem recentFilesMenuItem;
        private ToolStripMenuItem recentFileSampleItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem singleThreadToolStripMenuItem;
        private ToolStripMenuItem singleFileToolStripMenuItem;
        private ToolStripMenuItem allOpenedFilesToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem filterToolStripMenuItem;
        private ToolStripMenuItem logViewFiltersToolStripMenuItem;
        private ToolStripMenuItem showFiltersToolStripMenuItem;
        private ToolStripMenuItem addSelectedToFilterToolStripMenuItem;
        private ToolStripMenuItem threadListFiltersToolStripMenuItem;
        private ToolStripMenuItem showFiltersToolStripMenuItem1;
        private ToolStripMenuItem addSelectedToFilterToolStripMenuItem1;
        private ToolStripMenuItem highLigthToolStripMenuItem;
    }
}
