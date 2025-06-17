using OT_Performance_Tracer.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OT_Performance_Tracer.classes.Settings;

namespace OT_Performance_Tracer.forms
{
    public partial class fHighlight : Form
    {
        public fHighlight()
        {
            InitializeComponent();
        }

        #region "List View Custom Draw"

        //this region is mostly from https://www.csharphelper.com/howtos/howto_ownerdraw_listview.html

        private void lstItems_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            StringFormat string_format = new StringFormat();

            string_format.Alignment = StringAlignment.Center;
            string_format.LineAlignment = StringAlignment.Center;

            string text = lstItems.Columns[e.ColumnIndex].Text;

            e.Graphics.DrawString(text, lstItems.Font, new SolidBrush(lstItems.ForeColor), e.Bounds);

            //need to add 'border'
        }

        private void lstItems_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Get the ListView item
            ListViewItem? item = e.Item;

            if (item == null) return;

            // Draw.
            switch (e.ColumnIndex)
            {
                case 0:
                    // Draw the line's text
                    //display index is different, which seems to throw off the bounds here
                    Rectangle rect = new Rectangle(
                        lstItems.Columns[1].Width + e.Bounds.Left, e.Bounds.Top,
                        e.Bounds.Width, e.Bounds.Height);
                    e.Graphics.DrawString(item.Text, lstItems.Font, new SolidBrush(lstItems.ForeColor), rect);
                    break;

                case 1:
                    // Draw the lines color
                    e.Graphics.FillRectangle(new SolidBrush(item.SubItems[e.ColumnIndex].BackColor),
                        new Rectangle(
                            e.Bounds.Left + 1, e.Bounds.Top + 1,
                            e.Bounds.Width - 2, e.Bounds.Height - 2));

                    break;
            }

            // Draw the focus rectangle if appropriate.
            e.Graphics.ResetTransform();
            e.DrawFocusRectangle(e.Item.Bounds);
        }

        #endregion "List View Custom Draw"

        public void ShowHighlights()
        {
            Highlight[] data = Settings.LoadHighLights();

            //update list
            foreach (Highlight highlight in data)
            {
                ListViewItem item = new();
                ListViewItem.ListViewSubItem subItem = new();

                item.Text = highlight.filterText;
                subItem.BackColor = highlight.color;
                item.SubItems.Add(subItem);

                //add to list view
                lstItems.Items.Add(item);
            }

            this.ShowDialog();
        }

        private void cOK_Click(object sender, EventArgs e)
        {
            Highlight[] data = [];

            foreach (ListViewItem filter in lstItems.Items)
            {
                data = [.. data, new Highlight(filter.Text, filter.SubItems[1].BackColor)];
            }

            Settings.SaveHighlights(data);

            this.Close();
        }
    }
}