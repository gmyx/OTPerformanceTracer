using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OT_Performance_Tracer.classes
{
    public partial class fShowDetails : Form
    {
        public fShowDetails()
        {
            InitializeComponent();
        }

        public void ShowDetails(string message)
        {
            txtMessage.Text = message;

            this.ShowDialog();
        }

        private void cClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cAddFilter_Click(object sender, EventArgs e)
        {
            fAddEditFilter form = new();
            if (form.Add(txtMessage.Text) == DialogResult.Cancel) return;

            //add the filter and save
            Settings.addFilter(form.FilterValue, Settings.FilterTypes.Logfilter);
        }
    }
}
