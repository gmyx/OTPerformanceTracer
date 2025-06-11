namespace OT_Performance_Tracer.forms
{
    partial class fSearch
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
            txtSearchString = new TextBox();
            cFirst = new Button();
            cNext = new Button();
            SuspendLayout();
            // 
            // txtSearchString
            // 
            txtSearchString.Location = new Point(12, 12);
            txtSearchString.Name = "txtSearchString";
            txtSearchString.Size = new Size(652, 23);
            txtSearchString.TabIndex = 0;
            // 
            // cFirst
            // 
            cFirst.Location = new Point(508, 46);
            cFirst.Name = "cFirst";
            cFirst.Size = new Size(75, 23);
            cFirst.TabIndex = 1;
            cFirst.Text = "First";
            cFirst.UseVisualStyleBackColor = true;
            cFirst.Click += cFirst_Click;
            // 
            // cNext
            // 
            cNext.Location = new Point(589, 45);
            cNext.Name = "cNext";
            cNext.Size = new Size(75, 23);
            cNext.TabIndex = 2;
            cNext.Text = "Next";
            cNext.UseVisualStyleBackColor = true;
            cNext.Click += cNext_Click;
            // 
            // fSearch
            // 
            AcceptButton = cFirst;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 81);
            Controls.Add(cNext);
            Controls.Add(cFirst);
            Controls.Add(txtSearchString);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fSearch";
            Text = "fSearch";
            FormClosing += fSearch_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearchString;
        private Button cFirst;
        private Button cNext;
    }
}