using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tratatui
{
    public partial class GuestForm : Form
    {
        public GuestForm()
        {
            InitializeComponent();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            //Создать в БД заказ с выбранными блюдами
        }

        private void GuestForm_Load(object sender, EventArgs e)
        {
            //Последовательно загрузить из БД блюда по типам и положить их в ListView с кол-вом 0
            ListViewGroup appetisers = new ListViewGroup("Салаты и закуски");
            ListViewItem appetiser = new ListViewItem("Салат Цезарь", appetisers);
            appetiser.SubItems.Add("Классический салат Цезарь с курицей.");
            appetiser.SubItems.Add("$69,99");
            appetiser.SubItems.Add("0");
            MenuItem.Groups.Add(appetisers);
            MenuItem.Items.Add(appetiser);
        }

        private void MenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MenuItem.SelectedItems.Count != 0)
            {
                ListViewItem selection = MenuItem.SelectedItems[0];
                amtSelector.Value = Decimal.Parse(selection.SubItems[3].Text);
                amtSelector.Location = new Point(selection.SubItems[3].Bounds.X + selection.ListView.Top,
                                                 selection.SubItems[3].Bounds.Y + selection.ListView.Left);
                amtSelector.Visible = true;
                amtSelector.Focus();
            } else amtSelector.Visible = false; 
        }

        private void amtSelector_ValueChanged(object sender, EventArgs e)
        {
            if (MenuItem.SelectedItems.Count != 0)
            {
                ListViewItem selection = MenuItem.SelectedItems[0];
                selection.SubItems[3].Text = amtSelector.Value.ToString();
                ListViewItem? target = null;
                foreach (ListViewItem item in OrderList.Items)
                {
                    if (item.Text == selection.Text)
                    {
                        target = item; break;
                    }
                }
                if (target == null)
                {
                    if (amtSelector.Value == 0) return;
                    target = new ListViewItem(selection.Text);
                    target.SubItems.Add(amtSelector.Value.ToString());
                    target.SubItems.Add("$" + (amtSelector.Value * decimal.Parse(selection.SubItems[2].Text.Substring(1))).ToString());
                    OrderList.Items.Add(target);
                } else
                {
                    if (amtSelector.Value == 0) target.Remove();
                    else
                    {
                        target.SubItems[1].Text = amtSelector.Value.ToString();
                        target.SubItems[2].Text = "$" + (amtSelector.Value * decimal.Parse(selection.SubItems[2].Text.Substring(1))).ToString();
                    }
                    OrderList.Update();
                }
            }
            else amtSelector.Visible = false;

            decimal sum = 0;
            foreach (ListViewItem item in OrderList.Items) 
                sum += decimal.Parse(item.SubItems[2].Text.Substring(1));
            TotalCostLabel.Text = "$" + sum.ToString();
        }
    }
}
