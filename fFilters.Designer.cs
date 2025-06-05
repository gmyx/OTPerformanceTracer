namespace OT_Performance_Tracer
{
    partial class fFilters
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
            lstFilters = new ListView();
            cAdd = new Button();
            cEdit = new Button();
            cOK = new Button();
            cCancel = new Button();
            cDelete = new Button();
            SuspendLayout();
            // 
            // lstFilters
            // 
            lstFilters.FullRowSelect = true;
            lstFilters.Location = new Point(12, 3);
            lstFilters.Name = "lstFilters";
            lstFilters.Size = new Size(785, 355);
            lstFilters.TabIndex = 0;
            lstFilters.UseCompatibleStateImageBehavior = false;
            lstFilters.View = View.List;
            // 
            // cAdd
            // 
            cAdd.Location = new Point(12, 364);
            cAdd.Name = "cAdd";
            cAdd.Size = new Size(75, 23);
            cAdd.TabIndex = 1;
            cAdd.Text = "&Add";
            cAdd.UseVisualStyleBackColor = true;
            cAdd.Click += cAdd_Click;
            // 
            // cEdit
            // 
            cEdit.Location = new Point(93, 364);
            cEdit.Name = "cEdit";
            cEdit.Size = new Size(75, 23);
            cEdit.TabIndex = 2;
            cEdit.Text = "&Edit";
            cEdit.UseVisualStyleBackColor = true;
            cEdit.Click += cEdit_Click;
            // 
            // cOK
            // 
            cOK.Location = new Point(632, 364);
            cOK.Name = "cOK";
            cOK.Size = new Size(75, 23);
            cOK.TabIndex = 4;
            cOK.Text = "&OK";
            cOK.UseVisualStyleBackColor = true;
            cOK.Click += cOK_Click;
            // 
            // cCancel
            // 
            cCancel.Location = new Point(713, 364);
            cCancel.Name = "cCancel";
            cCancel.Size = new Size(75, 23);
            cCancel.TabIndex = 5;
            cCancel.Text = "&Cancel";
            cCancel.UseVisualStyleBackColor = true;
            // 
            // cDelete
            // 
            cDelete.Location = new Point(174, 364);
            cDelete.Name = "cDelete";
            cDelete.Size = new Size(75, 23);
            cDelete.TabIndex = 3;
            cDelete.Text = "&Delete";
            cDelete.UseVisualStyleBackColor = true;
            cDelete.Click += cDelete_Click;
            // 
            // fFilters
            // 
            AcceptButton = cOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cCancel;
            ClientSize = new Size(800, 396);
            Controls.Add(cDelete);
            Controls.Add(cCancel);
            Controls.Add(cOK);
            Controls.Add(cEdit);
            Controls.Add(cAdd);
            Controls.Add(lstFilters);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fFilters";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "fFilters";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private ListView lstFilters;
        private Button cAdd;
        private Button cEdit;
        private Button cOK;
        private Button cCancel;
        private Button cDelete;
    }
}