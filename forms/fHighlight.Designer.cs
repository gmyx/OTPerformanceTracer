namespace OT_Performance_Tracer.forms
{
    partial class fHighlight
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cOK = new Button();
            cCancel = new Button();
            cEdit = new Button();
            cAdd = new Button();
            lstItems = new ListView();
            chSearchText = new ColumnHeader();
            chHighligh = new ColumnHeader();
            cDelete = new Button();
            SuspendLayout();
            // 
            // cOK
            // 
            cOK.Location = new Point(290, 194);
            cOK.Name = "cOK";
            cOK.Size = new Size(75, 23);
            cOK.TabIndex = 4;
            cOK.Text = "&OK";
            cOK.UseVisualStyleBackColor = true;
            cOK.Click += cOK_Click;
            // 
            // cCancel
            // 
            cCancel.Location = new Point(371, 194);
            cCancel.Name = "cCancel";
            cCancel.Size = new Size(75, 23);
            cCancel.TabIndex = 5;
            cCancel.Text = "&Cancel";
            cCancel.UseVisualStyleBackColor = true;
            // 
            // cEdit
            // 
            cEdit.Location = new Point(93, 194);
            cEdit.Name = "cEdit";
            cEdit.Size = new Size(75, 23);
            cEdit.TabIndex = 2;
            cEdit.Text = "&Edit";
            cEdit.UseVisualStyleBackColor = true;
            // 
            // cAdd
            // 
            cAdd.Location = new Point(12, 194);
            cAdd.Name = "cAdd";
            cAdd.Size = new Size(75, 23);
            cAdd.TabIndex = 1;
            cAdd.Text = "&Add";
            cAdd.UseVisualStyleBackColor = true;
            // 
            // lstItems
            // 
            lstItems.Columns.AddRange(new ColumnHeader[] { chSearchText, chHighligh });
            lstItems.FullRowSelect = true;
            lstItems.Location = new Point(12, 12);
            lstItems.Name = "lstItems";
            lstItems.OwnerDraw = true;
            lstItems.Size = new Size(434, 176);
            lstItems.TabIndex = 0;
            lstItems.UseCompatibleStateImageBehavior = false;
            lstItems.View = View.Details;
            lstItems.DrawColumnHeader += lstItems_DrawColumnHeader;
            lstItems.DrawSubItem += lstItems_DrawSubItem;
            // 
            // chSearchText
            // 
            chSearchText.DisplayIndex = 1;
            chSearchText.Text = "Search Text";
            chSearchText.Width = 370;
            // 
            // chHighligh
            // 
            chHighligh.DisplayIndex = 0;
            chHighligh.Text = "Color";
            // 
            // cDelete
            // 
            cDelete.Location = new Point(174, 194);
            cDelete.Name = "cDelete";
            cDelete.Size = new Size(75, 23);
            cDelete.TabIndex = 3;
            cDelete.Text = "&Delete";
            cDelete.UseVisualStyleBackColor = true;
            // 
            // fHighlight
            // 
            AcceptButton = cOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cCancel;
            ClientSize = new Size(461, 227);
            Controls.Add(cDelete);
            Controls.Add(lstItems);
            Controls.Add(cAdd);
            Controls.Add(cEdit);
            Controls.Add(cCancel);
            Controls.Add(cOK);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fHighlight";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "fHighlight";
            ResumeLayout(false);
        }

        #endregion

        private Button cOK;
        private Button cCancel;
        private Button cEdit;
        private Button cAdd;
        private ListView lstItems;
        private Button cDelete;
        private ColumnHeader chSearchText;
        private ColumnHeader chHighligh;
    }
}