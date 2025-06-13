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

            //cScope.Items.Add(fSearch.Allfiles);

            //populate the dropdown
            foreach (Scope scope in Enum.GetValues<Scope>())
            {
                string? item = fSearch.ResourceManager.GetString(scope.ToString());

                if (item != null) cScope.Items.Add(item);
            }
        }

        public event EventHandler? SearchFirst;

        public event EventHandler? SearchNext;

        public enum Scope
        {
            SingleThread,
            SingleFile,
            AllFiles
        }

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

        public string SearchString => txtSearchString.Text;

        public Scope? SelectedScope
        {
            get
            {
                //derefrence the dromdown
                foreach (Scope scope in Enum.GetValues<Scope>())
                {
                    string? item = fSearch.ResourceManager.GetString(scope.ToString());

                    if (cScope.Text == item)
                    {
                        return scope;
                    }
                }

                return null;
            }
        }
    }
}