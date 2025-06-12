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
            label1 = new Label();
            cScope = new ComboBox();
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
            cFirst.TabIndex = 3;
            cFirst.Text = "First";
            cFirst.UseVisualStyleBackColor = true;
            cFirst.Click += cFirst_Click;
            // 
            // cNext
            // 
            cNext.Location = new Point(589, 45);
            cNext.Name = "cNext";
            cNext.Size = new Size(75, 23);
            cNext.TabIndex = 4;
            cNext.Text = "Next";
            cNext.UseVisualStyleBackColor = true;
            cNext.Click += cNext_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 50);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Scope";
            // 
            // cScope
            // 
            cScope.FormattingEnabled = true;
            cScope.Items.AddRange(new object[] { "Current Request", "Current Thread file", "All Files" });
            cScope.Location = new Point(57, 46);
            cScope.Name = "cScope";
            cScope.Size = new Size(145, 23);
            cScope.TabIndex = 2;
            // 
            // fSearch
            // 
            AcceptButton = cFirst;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 81);
            Controls.Add(cScope);
            Controls.Add(label1);
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
        private Label label1;
        private ComboBox cScope;
    }
}