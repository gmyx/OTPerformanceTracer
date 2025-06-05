namespace OT_Performance_Tracer
{
    partial class fAddEditFilter
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
            txtFilter = new TextBox();
            cOK = new Button();
            cCancel = new Button();
            SuspendLayout();
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(12, 12);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(620, 23);
            txtFilter.TabIndex = 0;
            // 
            // cOK
            // 
            cOK.Location = new Point(476, 41);
            cOK.Name = "cOK";
            cOK.Size = new Size(75, 23);
            cOK.TabIndex = 1;
            cOK.Text = "&OK";
            cOK.UseVisualStyleBackColor = true;
            cOK.Click += cOK_Click;
            // 
            // cCancel
            // 
            cCancel.Location = new Point(557, 41);
            cCancel.Name = "cCancel";
            cCancel.Size = new Size(75, 23);
            cCancel.TabIndex = 2;
            cCancel.Text = "&Cancel";
            cCancel.UseVisualStyleBackColor = true;
            // 
            // fAddEditFilter
            // 
            AcceptButton = cOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cCancel;
            ClientSize = new Size(644, 74);
            Controls.Add(cCancel);
            Controls.Add(cOK);
            Controls.Add(txtFilter);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fAddEditFilter";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "fAddEditFilter";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFilter;
        private Button cOK;
        private Button cCancel;
    }
}