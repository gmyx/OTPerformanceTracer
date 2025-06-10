using OT_Performance_Tracer.classes;

namespace OT_Performance_Tracer
{
    public partial class fFilters : Form
    {

        private Settings.FilterTypes _filterType;
        public fFilters()
        {
            InitializeComponent();
        }

        internal void ShowList(Settings.FilterTypes filterType)
        {
            _filterType = filterType;
            UpdateList(_filterType);
            this.ShowDialog();
        }

        private void UpdateList(Settings.FilterTypes filterType)
        {
            //read registry
            string[] filters = Settings.LoadFilters(filterType);

            //create list items
            foreach (string filter in filters)
            {
                lstFilters.Items.Add(filter);
            }
        }

        private void cOK_Click(object sender, EventArgs e)
        {
            string[] data = [];

            foreach (ListViewItem filter in lstFilters.Items)
            {
                data = [.. data, filter.Text];
            }

            Settings.SaveFilters(data, _filterType);

            this.Close();
        }

        private void cAdd_Click(object sender, EventArgs e)
        {
            fAddEditFilter form = new();

            if (form.Add("") == DialogResult.Cancel) return;

            //add the filter to the list
            lstFilters.Items.Add(form.FilterValue);
        }

        private void cEdit_Click(object sender, EventArgs e)
        {
            if (lstFilters.SelectedItems.Count == 0) return;

            fAddEditFilter form = new();

            if (form.Add(lstFilters.SelectedItems[0].Text) == DialogResult.Cancel) return;

            lstFilters.SelectedItems[0].Text = form.FilterValue;
        }

        private void cDelete_Click(object sender, EventArgs e)
        {
            if (lstFilters.SelectedItems.Count == 0) return;

            if (MessageBox.Show("Delete selected item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            lstFilters.SelectedItems[0].Remove();
        }
    }
}