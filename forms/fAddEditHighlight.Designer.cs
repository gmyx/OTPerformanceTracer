namespace OT_Performance_Tracer.forms
{
    partial class fAddEditHighlight
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
            colorDialog1 = new ColorDialog();
            txtFilter = new TextBox();
            cCancel = new Button();
            icoColor = new PictureBox();
            cOK = new Button();
            cChangeColor = new Button();
            ((System.ComponentModel.ISupportInitialize)icoColor).BeginInit();
            SuspendLayout();
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(68, 12);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(570, 23);
            txtFilter.TabIndex = 0;
            // 
            // cCancel
            // 
            cCancel.Location = new Point(561, 41);
            cCancel.Name = "cCancel";
            cCancel.Size = new Size(75, 23);
            cCancel.TabIndex = 3;
            cCancel.Text = "&Cancel";
            cCancel.UseVisualStyleBackColor = true;
            cCancel.Click += cCancel_Click;
            // 
            // icoColor
            // 
            icoColor.Location = new Point(12, 12);
            icoColor.Name = "icoColor";
            icoColor.Size = new Size(50, 50);
            icoColor.TabIndex = 3;
            icoColor.TabStop = false;
            icoColor.Click += cChangeColor_Click;
            // 
            // cOK
            // 
            cOK.Location = new Point(480, 41);
            cOK.Name = "cOK";
            cOK.Size = new Size(75, 23);
            cOK.TabIndex = 2;
            cOK.Text = "&OK";
            cOK.UseVisualStyleBackColor = true;
            cOK.Click += cOK_Click;
            // 
            // cChangeColor
            // 
            cChangeColor.Location = new Point(68, 41);
            cChangeColor.Name = "cChangeColor";
            cChangeColor.Size = new Size(75, 23);
            cChangeColor.TabIndex = 1;
            cChangeColor.Text = "Change";
            cChangeColor.UseVisualStyleBackColor = true;
            cChangeColor.Click += cChangeColor_Click;
            // 
            // fAddEditHighlight
            // 
            AcceptButton = cOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cCancel;
            ClientSize = new Size(648, 72);
            Controls.Add(cChangeColor);
            Controls.Add(cOK);
            Controls.Add(icoColor);
            Controls.Add(cCancel);
            Controls.Add(txtFilter);
            Name = "fAddEditHighlight";
            StartPosition = FormStartPosition.CenterParent;
            Text = "fAddEditHighlight";
            ((System.ComponentModel.ISupportInitialize)icoColor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ColorDialog colorDialog1;
        private TextBox txtFilter;
        private Button cCancel;
        private PictureBox icoColor;
        private Button cOK;
        private Button cChangeColor;
    }
}