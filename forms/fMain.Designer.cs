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
            logViewFiltersToolStripMenuItem = new ToolStripMenuItem();
            showFiltersToolStripMenuItem = new ToolStripMenuItem();
            threadListFiltersToolStripMenuItem = new ToolStripMenuItem();
            filterThreadFuncToolStripMenuItem = new ToolStripMenuItem();
            openThreadLogDialog = new OpenFileDialog();
            splitContainer1 = new SplitContainer();
            tvBlocks = new TreeView();
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
            mLstContext.SuspendLayout();
            ssData.SuspendLayout();
            SuspendLayout();
            // 
            // mMenu
            // 
            mMenu.ImageScalingSize = new Size(36, 36);
            mMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, filterToolStripMenuItem });
            mMenu.Location = new Point(0, 0);
            mMenu.Name = "mMenu";
            mMenu.Padding = new Padding(13, 5, 0, 5);
            mMenu.Size = new Size(2419, 53);
            mMenu.TabIndex = 1;
            mMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadFolderToolStripMenuItem, loadThreadLogToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(80, 43);
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
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logViewFiltersToolStripMenuItem, threadListFiltersToolStripMenuItem });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            filterToolStripMenuItem.Size = new Size(98, 43);
            filterToolStripMenuItem.Text = "Filter";
            // 
            // logViewFiltersToolStripMenuItem
            // 
            logViewFiltersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showFiltersToolStripMenuItem });
            logViewFiltersToolStripMenuItem.Name = "logViewFiltersToolStripMenuItem";
            logViewFiltersToolStripMenuItem.Size = new Size(403, 48);
            logViewFiltersToolStripMenuItem.Text = "Log View Filters";
            // 
            // showFiltersToolStripMenuItem
            // 
            showFiltersToolStripMenuItem.Name = "showFiltersToolStripMenuItem";
            showFiltersToolStripMenuItem.Size = new Size(309, 48);
            showFiltersToolStripMenuItem.Text = "Show Filters";
            showFiltersToolStripMenuItem.Click += showFiltersToolStripMenuItem_Click;
            // 
            // threadListFiltersToolStripMenuItem
            // 
            threadListFiltersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filterThreadFuncToolStripMenuItem });
            threadListFiltersToolStripMenuItem.Name = "threadListFiltersToolStripMenuItem";
            threadListFiltersToolStripMenuItem.Size = new Size(403, 48);
            threadListFiltersToolStripMenuItem.Text = "Thread List Filters";
            // 
            // filterThreadFuncToolStripMenuItem
            // 
            filterThreadFuncToolStripMenuItem.Name = "filterThreadFuncToolStripMenuItem";
            filterThreadFuncToolStripMenuItem.Size = new Size(403, 48);
            filterThreadFuncToolStripMenuItem.Text = "Filter Thread Func";
            filterThreadFuncToolStripMenuItem.Click += filterThreadFuncToolStripMenuItem_Click;
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
            splitContainer1.Location = new Point(0, 53);
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
            splitContainer1.Size = new Size(2419, 1447);
            splitContainer1.SplitterDistance = 805;
            splitContainer1.SplitterWidth = 9;
            splitContainer1.TabIndex = 2;
            // 
            // tvBlocks
            // 
            tvBlocks.Dock = DockStyle.Fill;
            tvBlocks.HideSelection = false;
            tvBlocks.Location = new Point(0, 0);
            tvBlocks.Margin = new Padding(6, 7, 6, 7);
            tvBlocks.Name = "tvBlocks";
            tvBlocks.Size = new Size(805, 1447);
            tvBlocks.TabIndex = 1;
            tvBlocks.AfterSelect += tvBlocks_AfterSelect;
            // 
            // cStats
            // 
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
            lstLines.Size = new Size(1600, 1300);
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
            chData.Width = 400;
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
        private ToolStripMenuItem loadFolderToolStripMenuItem;
        private FolderBrowserDialog folderLogBrowserDialog;
        private ContextMenuStrip mLstContext;
        private ToolStripMenuItem addToFiltersToolStripMenuItem;
        private ToolStripProgressBar ssProgress;
        private ToolStripStatusLabel ssGap;
        private ToolStripMenuItem openInWindowToolStripMenuItem;
        private ColumnHeader chLevel;
        private ToolStripMenuItem logViewFiltersToolStripMenuItem;
        private ToolStripMenuItem showFiltersToolStripMenuItem;
        private ToolStripMenuItem threadListFiltersToolStripMenuItem;
        private ToolStripMenuItem filterThreadFuncToolStripMenuItem;
    }
}
