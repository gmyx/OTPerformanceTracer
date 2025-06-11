using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OT_Performance_Tracer.forms
{
    public partial class fSearch : Form
    {
        public fSearch()
        {
            InitializeComponent();
        }

        public event EventHandler? SearchFirst;
        public event EventHandler? SearchNext;

        private void cFirst_Click(object sender, EventArgs e)
        {
            SearchFirst?.Invoke(this, EventArgs.Empty);
        }

        private void cNext_Click(object sender, EventArgs e)
        {
            SearchNext?.Invoke(this, EventArgs.Empty);
        }

        private void fSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cancel unless it's for a shutdown
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        public string SearchString
        {
            get { return txtSearchString.Text; }
        }
    }
}
