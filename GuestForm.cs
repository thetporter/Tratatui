using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
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

        public List<Dish> Menu = new List<Dish>();
        public Table table;

        private void OrderButton_Click(object sender, EventArgs e)
        {
            if (OrderList.Items.Count == 0) return;

            //Создание заказа
            Order order = new Order();
            order.Status = 0;
            order.Type = OrderType.Order;
            order.CreationTime = TimeOnly.Parse(DateTime.Now.TimeOfDay.ToString());
            order.Active = true;
            order.Table = table;
            order.Dishes = new List<Dish>();
            DB.Database.Orders.Add(order);
            DB.Database.SaveChanges();

            //Наполнение заказа, создание или изменение соответствующих объектов DishorderLink
            foreach (ListViewItem item in OrderList.Items)
            {
                Dish dish = Menu.Find(d => {  return d.Name == item.Text; });
                if (dish == null) { MessageBox.Show("Что-то пошло не так. Приносим свои извинения!"); return; }
                order.Dishes.Add(dish);

                DishorderLink link = DB.Database.DishOrder.Find(order.Id, dish.Id);
                if (link == null)
                {
                    link = new DishorderLink();
                    link.DishId = dish.Id;
                    link.Dish = dish;
                    link.OrderId = order.Id;
                    link.Order = order;
                    link.Amount = int.Parse(item.SubItems[1].Text);
                    DB.Database.DishOrder.Add(link);
                }
                else link.Amount = int.Parse(item.SubItems[1].Text);
            }
            DB.Database.SaveChanges();
            DB.UpdateAll();
            WaitingForm wait = new WaitingForm();
            wait.guestForm = this;
            wait.awaitedorder = order;
            wait.NumberLabel.Text = order.Id.ToString();
            wait.Show();
            this.Enabled = false;
        }

        private void GuestForm_Load(object sender, EventArgs e)
        {
            //Определение столика
            List<Table> avail = new List<Table>();
            foreach (Table t in DB.Database.Tables)
                { if (t.State == TableState.Free) avail.Add(t); }
            if (avail.Count == 0)
            { 
                this.Enabled = false;
                MessageBox.Show("Все столики сейчас заняты. Администрация ресторана приносит свои извинения за причиненные неудобства.");
                this.Close();
                return;
            }
            table = DB.Database.Tables.Find(avail[RandomNumberGenerator.GetInt32(0, avail.Count)].Id);

            //Заполнение меню
            foreach (Dish d in DB.Database.Dishes)
            {
                Menu.Add(d);

                ListViewItem dish = new ListViewItem([d.Name,
                                                      d.Description,
                                                      $"${d.Price.ToString()}",
                                                      "0"]);
                ListViewGroup group;
                switch (d.Type)
                {
                    case DishType.Appetiser:
                        group = MenuItem.Groups[0];
                        break;
                    case DishType.MainDish:
                        group = MenuItem.Groups[1];
                        break;
                    case DishType.SideDish:
                        group = MenuItem.Groups[2];
                        break;
                    case DishType.Dessert:
                        group = MenuItem.Groups[3];
                        break;
                    case DishType.Drink:
                        group = MenuItem.Groups[4];
                        break;
                    default:
                        group = MenuItem.Groups[5];
                        break;
                }
                group.Items.Add(dish);
                MenuItem.Items.Add(dish);
            }
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
            }
            else amtSelector.Visible = false;
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
                }
                else
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

        private void GuestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (Application.OpenForms.Count == 1) Application.Exit();
        }
    }
}
