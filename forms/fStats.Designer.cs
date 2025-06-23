namespace OT_Performance_Tracer.forms
{
    partial class fStats
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
            lstItems = new ListView();
            chKey = new ColumnHeader();
            chValue = new ColumnHeader();
            cClose = new Button();
            SuspendLayout();
            // 
            // lstItems
            // 
            lstItems.Columns.AddRange(new ColumnHeader[] { chKey, chValue });
            lstItems.Dock = DockStyle.Fill;
            lstItems.FullRowSelect = true;
            lstItems.GridLines = true;
            lstItems.Location = new Point(0, 0);
            lstItems.Name = "lstItems";
            lstItems.Size = new Size(1623, 450);
            lstItems.TabIndex = 0;
            lstItems.UseCompatibleStateImageBehavior = false;
            lstItems.View = View.Details;
            // 
            // chKey
            // 
            chKey.Tag = "";
            chKey.Text = "Key";
            // 
            // chValue
            // 
            chValue.Text = "Value";
            // 
            // cClose
            // 
            cClose.Location = new Point(0, 0);
            cClose.Name = "cClose";
            cClose.Size = new Size(169, 52);
            cClose.TabIndex = 1;
            cClose.Text = "&Close";
            cClose.UseVisualStyleBackColor = true;
            cClose.Click += cClose_Click;
            // 
            // fStats
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cClose;
            ClientSize = new Size(1623, 450);
            Controls.Add(lstItems);
            Controls.Add(cClose);
            MinimizeBox = false;
            Name = "fStats";
            ShowInTaskbar = false;
            Text = "fStats";
            ResumeLayout(false);
        }

        #endregion

        private ListView lstItems;
        private Button cClose;
        private ColumnHeader chKey;
        private ColumnHeader chValue;
    }
}