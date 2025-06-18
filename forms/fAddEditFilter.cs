namespace OT_Performance_Tracer
{
    public partial class fAddEditFilter : Form
    {
        public fAddEditFilter()
        {
            InitializeComponent();
        }

        public DialogResult buttonPressed = DialogResult.Cancel;

        public string FilterValue => txtFilter.Text;

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

        private void cCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}