namespace OT_Performance_Tracer.classes
{
    partial class fShowDetails
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
            txtMessage = new TextBox();
            cClose = new Button();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.Location = new Point(12, 12);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ReadOnly = true;
            txtMessage.ScrollBars = ScrollBars.Vertical;
            txtMessage.Size = new Size(491, 433);
            txtMessage.TabIndex = 0;
            // 
            // cClose
            // 
            cClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cClose.Location = new Point(428, 452);
            cClose.Name = "cClose";
            cClose.Size = new Size(75, 23);
            cClose.TabIndex = 1;
            cClose.Text = "&Close";
            cClose.UseVisualStyleBackColor = true;
            cClose.Click += cClose_Click;
            // 
            // fShowDetails
            // 
            AcceptButton = cClose;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cClose;
            ClientSize = new Size(515, 487);
            Controls.Add(cClose);
            Controls.Add(txtMessage);
            Name = "fShowDetails";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "showDetails";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMessage;
        private Button cClose;
    }
}