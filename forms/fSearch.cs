using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
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

            //populate the dropdown(
            foreach (Scope scope in Enum.GetValues<Scope>())
            {
                string? item = ResourceManager.GetString(scope.ToString());

                if (item != null) cScope.Items.Add(item);
            }
        }

        public event EventHandler? SearchFirst;

        public event EventHandler? SearchNext;

        private ResourceManager resourceMan;

        internal ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("OT_Performance_Tracer.forms.fSearch", typeof(fSearch).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        public enum Scope
        {
            SingleThread,
            SingleFile,
            AllFiles
        }

        public void ShowSearch(Scope scope)
        {
            switch (txtSearchString.Text)
            {
                case "":
                    this.AcceptButton = cFirst;
                    break;

                default:
                    this.AcceptButton = cNext;
                    break;
            }

            this.SelectedScope = scope;
            this.Show();
        }

        private void cFirst_Click(object sender, EventArgs e)
        {
            //this.TransparencyKey = System.Drawing.SystemColors.Control;
            //this.Opacity = 50;
            if (txtSearchString.Text != "") { this.AcceptButton = cNext; }
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
                    string? item = ResourceManager.GetString(scope.ToString());

                    if (cScope.Text == item)
                    {
                        return scope;
                    }
                }

                return null;
            }
            set
            {
                // derefrence the dromdown
                cScope.Text = ResourceManager.GetString(value.ToString());
            }
        }
    }
}