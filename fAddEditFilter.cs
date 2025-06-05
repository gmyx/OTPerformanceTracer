using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OT_Performance_Tracer
{
    public partial class fAddEditFilter : Form
    {
        public fAddEditFilter()
        {
            InitializeComponent();
        }

        public DialogResult buttonPressed = DialogResult.Cancel;

        public string FilterValue { get { return txtFilter.Text; } }

        public DialogResult Add(string suggested = "")
        {
            txtFilter.Text = suggested;

            this.ShowDialog();

            return buttonPressed;
        }

        private void cOK_Click(object sender, EventArgs e)
        {
            buttonPressed = DialogResult.OK;
            this.Close();
        }
    }
}
