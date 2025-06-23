using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OT_Performance_Tracer.forms
{
    public partial class fStats : Form
    {
        public fStats()
        {
            InitializeComponent();
        }

        public void ShowStats(string statAssoc)
        {
            //read the assoc, which is mostly a KeyValuePair, seperated by commas
            //format is 'soemthing'=number or string
            //regEx for the stats assoc, which does not have sub assocs
            /// ('.*?')=(.*?)(?:,|$)
            Regex pattern = new Regex(@"('.*?')=(.*?)(?:,|$)", RegexOptions.Singleline);
            string CleannedMessage = statAssoc.Substring(2, statAssoc.Length - 3);
            MatchCollection results = pattern.Matches(CleannedMessage);

            foreach (Match match in results)
            {
                ListViewItem item = new ListViewItem();
                item.Text = match.Groups[1].Value;
                item.SubItems.Add(match.Groups[2].Value);

                lstItems.Items.Add(item);
            }

            //now auto resize
            lstItems.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstItems.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            this.ShowDialog();
        }

        private void cClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}