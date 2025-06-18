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
    public partial class fAddEditHighlight : Form
    {
        public fAddEditHighlight()
        {
            InitializeComponent();
        }

        public DialogResult buttonPressed = DialogResult.Cancel;
        public string FilterValue => txtFilter.Text;
        public Color HighlighColor => icoColor.BackColor;

        public DialogResult Add(Color? suggestedColor, string suggested = "")
        {
            txtFilter.Text = suggested;

            if (suggestedColor == null)
            {
                suggestedColor = SystemColors.Control; //default form value
            }

            icoColor.BackColor = (Color)suggestedColor;

            this.ShowDialog();

            return buttonPressed;
        }

        private void cOK_Click(object sender, EventArgs e)
        {
            buttonPressed = DialogResult.OK;
            this.Close();
        }

        private void cCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cChangeColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = icoColor.BackColor;
            if (colorDialog1.ShowDialog() != DialogResult.OK) return;

            icoColor.BackColor = colorDialog1.Color;
        }
    }
}