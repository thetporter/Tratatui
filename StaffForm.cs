using Microsoft.EntityFrameworkCore;
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
    public partial class StaffForm : Form
    {
        public StaffForm(Staff staff)
        {
            InitializeComponent();
            user = staff;
            switch (staff.Type)
            {
                case StaffType.Waiter:
                    strat = new WaiterStrategy();
                    break;
                case StaffType.Chef:
                    strat = new ChefStrategy();
                    break;
                case StaffType.Admin:
                    this.Close();
                    break;
                default:
                    this.Close();
                    break;
            }
            strat.TargetForm = this;
            strat.SetVisuals();
            strat.UpdateThings();
        }

        public Staff user;
        public IFormstrat strat;
        public Order ActiveOrder;

        public void UpdateInfo() { strat.UpdateThings(); }
    }

    public interface IFormstrat
    {
        public StaffForm TargetForm { get; set; }
        public void SetVisuals();
        public void UpdateThings();
        public void Button1Function(object sender, EventArgs e);
        public void Button2Function(object sender, EventArgs e);
        public void TableButtonFunction(object sender, EventArgs e);
        public void OrderListSelectionChangeFunction(object sender, EventArgs e);
    }

    public class ChefStrategy : IFormstrat
    {
        private StaffForm target;
        public ChefStrategy()
        {
            
        }

        public StaffForm TargetForm { get { return target; } set { target = value; } }

        public void SetVisuals()
        {
            target.EditedListView.Columns.Add("Блюдо", 250);
            target.EditedListView.Columns.Add("Кол-во", 50);
            target.EditedListView.Columns.Add("Рецепт", 900);

            target.button1.Text = "Увеличить степень готовности";
            target.button1.Click += Button1Function;
            target.button1.Enabled = false;
            target.button2.Text = "Книга рецептов";
            target.button2.Click += Button2Function;

            target.OrderList.SelectedIndexChanged += OrderListSelectionChangeFunction;
            target.EditedListView.SelectedIndexChanged += EditedListSelectionChangeFunction;

            foreach (Button btn in target.Controls)
                if (btn.Text.StartsWith("Столик ")) btn.Click += TableButtonFunction;

            target.TopLabel.Text = """
                    Нажмите на столик, чтобы отобразить его заказ.
                    Информация о заказе появится здесь.
                """;
        }
        public void UpdateThings()
        {
            foreach (Table t in DB.Database.Tables)
            {
                Button tbtn = target.Controls.OfType<Button>().ToList().Find(btn => { return btn.Text.EndsWith(t.Id.ToString()); });
                if (target.Controls.Contains(tbtn))
                {
                    switch (t.State)
                    {
                        case TableState.Free:
                            tbtn.BackColor = Control.DefaultBackColor;
                            tbtn.Enabled = false;
                            break;
                        case TableState.Ordering:
                            tbtn.BackColor = Control.DefaultBackColor;
                            tbtn.Enabled = false;
                            break;
                        case TableState.Waiting:
                            tbtn.BackColor = Color.Green;
                            tbtn.Enabled = true;
                            break;
                        case TableState.Calling:
                            tbtn.BackColor = Control.DefaultBackColor;
                            tbtn.Enabled = true;
                            break;
                        case TableState.Served:
                            tbtn.BackColor = Control.DefaultBackColor;
                            tbtn.Enabled = false;
                            break;
                        case TableState.Finished:
                            tbtn.BackColor = Color.CadetBlue;
                            tbtn.Enabled = false;
                            break;
                        default:
                            tbtn.BackColor = Control.DefaultBackColor;
                            tbtn.Enabled = false;
                            break;
                    }
                }
            }
            foreach (Order ord in DB.Database.Orders)
            {
                if (ord.Type != OrderType.Order || !ord.Active) continue;

                string staffonorder = "";
                foreach (Staff st in DB.Database.Staff)
                {
                    if (st.Orders.Contains(ord)) staffonorder += st.Id.ToString() + ", ";
                }
                staffonorder = staffonorder.TrimEnd([',', ' ']);

                target.OrderList.Items.Add(new ListViewItem([ord.Id.ToString(),
                                                           ord.Table.ToString(),
                                                           ord.CreationTime.ToString(),
                                                           staffonorder,
                                                           StatusConverter.Do(ord.Status)]));
            }
        }
        public void Button1Function(object sender, EventArgs e)
        {
            target.ActiveOrder.Status += 1;
            DB.Database.SaveChanges();
        }
        public void Button2Function(object sender, EventArgs e)
        {
            RecipesForm recipebook = new RecipesForm();
            recipebook.Show();
        }
        public void TableButtonFunction(object sender, EventArgs e)
        {
            foreach (ListViewItem item in target.OrderList.Items.Find((sender as Button).Text.Substring(7), true))
            {
                if (item.SubItems[1].Text == ((sender as Button).Text.Substring(7)))
                {
                    item.Selected = true;
                    break;
                }
            }
        }
        public void OrderListSelectionChangeFunction(object sender, EventArgs e)
        {

            if (target.OrderList.SelectedItems.Count == 1)
            {
                if (target.OrderList.SelectedItems[0].SubItems[4].Text != "Сейчас принесем!")
                    target.button1.Enabled = true;
                else target.button1.Enabled = false;
                target.ActiveOrder = DB.Database.Orders.Find(int.Parse(target.OrderList.SelectedItems[0].Text));
                foreach (Dish di in target.ActiveOrder.Dishes)
                {
                    target.EditedListView.Items.Add(new ListViewItem([di.Name,
                                                                      di.Description,
                                                                      di.Recipe]));
                }
            }
            else
            {
                target.button1.Enabled = false;
                target.EditedListView.Items.Clear();
                target.ActiveOrder = null;
            }
            
        }
        public void EditedListSelectionChangeFunction(object sender, EventArgs e)
        {
            //Вывести рецепт выбранного блюда
            target.TopLabel.Text = target.EditedListView.SelectedItems[0].SubItems[2].Text;
        }
    }

    public class WaiterStrategy : IFormstrat
    {
        private StaffForm target;
        public WaiterStrategy()
        {

        }

        public StaffForm TargetForm { get { return target; } set { target = value; } }
        public void SetVisuals()
        {
            target.EditedListView.Columns.Add("Блюдо", 250);
            target.EditedListView.Columns.Add("Количество", 260);
            target.EditedListView.Columns.Add("Сумма", 261);

            target.button1.Text = "Взять заказ";
            target.button1.Click += Button1Function;
            target.button1.Enabled = false;
            target.button2.Text = "Подтвердить выполнение";
            target.button2.Click += Button2Function;
            target.button2.Enabled = false;

            target.OrderList.SelectedIndexChanged += OrderListSelectionChangeFunction;

            foreach (Button btn in target.Controls)
                if (btn.Text.StartsWith("Столик ")) btn.Click += TableButtonFunction;

            target.TopLabel.Text = """
                        Синий столик требует уборки. Зеленые столики ожидают свои заказы. Красные столики подзывают официанта.
                        Обведенные синим столики обслужены другими официантами.
                        Нажмите на столик, чтобы принять на себя его обслуживание. Столики, обслуживаемые вами, имеют красную обводку.
                        """;
        }
        public void UpdateThings()
        {
            foreach (Table t in DB.Database.Tables)
            {
                Button tbtn = target.Controls.OfType<Button>().ToList().Find(btn => { return btn.Text.EndsWith(t.Id.ToString()); });
                if (target.Controls.Contains(tbtn))
                {
                    switch (t.State) 
                    {
                        case TableState.Free:
                            tbtn.BackColor = Control.DefaultBackColor;
                            tbtn.Enabled = false;
                            break;
                        case TableState.Ordering:
                            tbtn.BackColor = Control.DefaultBackColor;
                            tbtn.Enabled = false;
                            break;
                        case TableState.Waiting:
                            tbtn.BackColor = Color.Green;
                            tbtn.Enabled = true;
                            break;
                        case TableState.Calling:
                            tbtn.BackColor = Color.IndianRed;
                            tbtn.Enabled = true;
                            break;
                        case TableState.Served:
                            tbtn.BackColor = Control.DefaultBackColor;
                            tbtn.Enabled = false;
                            break;
                        case TableState.Finished:
                            tbtn.BackColor = Color.CadetBlue;
                            tbtn.Enabled = false;
                            break;
                        default:
                            tbtn.BackColor = Control.DefaultBackColor;
                            tbtn.Enabled = false;
                            break;
                    }
                }

                Order tableorder = DB.Database.Orders.ToList<Order>().Find(ord => { return (ord.Table.Id == t.Id && ord.Active); });
                int StaffId = DB.Database.Staff.ToList<Staff>().Find(st => { return (st.Orders.Contains(tableorder)); }).Id;
                if (StaffId == target.user.Id) tbtn.ForeColor = Color.Red;
                else if (DB.Database.Staff.Find(StaffId) != null) tbtn.ForeColor = Color.Blue;
                else tbtn.ForeColor = Control.DefaultForeColor;
            }

            foreach (Order ord in DB.Database.Orders)
            {
                if (!ord.Active) continue;

                string staffonorder = "";
                foreach (Staff st in DB.Database.Staff)
                {
                    if (st.Orders.Contains(ord)) staffonorder += st.Id.ToString() + ", ";
                }
                staffonorder = staffonorder.TrimEnd([',', ' ']);

                target.OrderList.Items.Add(new ListViewItem([ord.Id.ToString(),
                                                           ord.Table.ToString(),
                                                           ord.CreationTime.ToString(),
                                                           staffonorder,
                                                           StatusConverter.Do(ord.Status)]));
            }
        }
        public void Button1Function(object sender, EventArgs e)
        {
            //Установить официанта для заказа в БД либо снять официанта с заказа в БД
            UpdateThings();
        }
        public void Button2Function(object sender, EventArgs e)
        {
            //Удалить заказ/отметить как выполненный
            UpdateThings();
        }
        public void TableButtonFunction(object sender, EventArgs e)
        {
            //Установить официанта для заказа в БД
            UpdateThings();
        }
        public void OrderListSelectionChangeFunction(object sender, EventArgs e)
        {
            //Запросить информацию о стоимости заказа из БД и отобразить ее в EditedListView

            if (target.OrderList.SelectedItems.Count > 0)
            {
                if (target.OrderList.SelectedItems[0].SubItems[3].Text == "")
                {
                    target.button1.Text = "Взять заказ";
                    target.button1.Enabled = true;
                }
                else if (target.OrderList.SelectedItems[0].SubItems[3].Text == target.user.Id.ToString())
                {
                    target.button1.Text = "Отказаться от заказа";
                    target.button1.Enabled = true;
                }
                else target.button1.Enabled = false;
            }
            else target.button1.Enabled = false;

            decimal sum = 0;
            foreach (ListViewItem it in target.EditedListView.Items)
                sum += decimal.Parse(it.SubItems[2].Text.Substring(1));
            if (sum > 0) target.TopLabel.Text = "Итоговая стоимость заказа: $" + sum.ToString();
            else target.TopLabel.Text = """
                        Синий столик требует уборки. Зеленые столики ожидают свои заказы. Красные столики подзывают официанта.
                        Светлые цвета обозначают столики, принятые другими официантами. Нажмите на столик, чтобы принять на себя его обслуживание.
                        Столики, обслуживаемые вами, имеют красную обводку.
                        """;
        }

        public class AdminStrategy : IFormstrat
        {
            private StaffForm target;
            public AdminStrategy()
            {

            }

            public StaffForm TargetForm { get { return target; } set { target = value; } }
            public void SetVisuals()
            {
                target.EditedListView.Columns.Add("Код", 50);
                target.EditedListView.Columns.Add("Имя", 460);
                target.EditedListView.Columns.Add("Заказы", 261);

                target.button1.Text = "Книга рецептов";
                target.button1.Click += Button1Function;
                target.button1.Enabled = true;
                target.button2.Text = "Список сотрудников";
                target.button2.Click += Button2Function;
                target.button2.Enabled = true;

                target.OrderList.SelectedIndexChanged += OrderListSelectionChangeFunction;

                foreach (Button btn in target.Controls)
                    if (btn.Text.StartsWith("Столик ")) btn.Click += TableButtonFunction;

                target.TopLabel.Text = """
                            
                        """;
            }
            public void UpdateThings()
            {
                foreach (Table t in DB.Database.Tables)
                {
                    Button tbtn = target.Controls.OfType<Button>().ToList().Find(btn => { return btn.Text.EndsWith(t.Id.ToString()); });
                    if (target.Controls.Contains(tbtn))
                    {
                        switch (t.State)
                        {
                            case TableState.Free:
                                tbtn.BackColor = Control.DefaultBackColor;
                                tbtn.Enabled = false;
                                break;
                            case TableState.Ordering:
                                tbtn.BackColor = Control.DefaultBackColor;
                                tbtn.Enabled = false;
                                break;
                            case TableState.Waiting:
                                tbtn.BackColor = Color.Green;
                                tbtn.Enabled = true;
                                break;
                            case TableState.Calling:
                                tbtn.BackColor = Control.DefaultBackColor;
                                tbtn.Enabled = true;
                                break;
                            case TableState.Served:
                                tbtn.BackColor = Control.DefaultBackColor;
                                tbtn.Enabled = true;
                                break;
                            case TableState.Finished:
                                tbtn.BackColor = Color.CadetBlue;
                                tbtn.Enabled = true;
                                break;
                            default:
                                tbtn.BackColor = Control.DefaultBackColor;
                                tbtn.Enabled = false;
                                break;
                        }
                    }
                }
                foreach (Order ord in DB.Database.Orders)
                {
                    if (ord.Type != OrderType.Order || !ord.Active) continue;

                    string staffonorder = "";
                    foreach (Staff st in DB.Database.Staff)
                    {
                        if (st.Orders.Contains(ord)) staffonorder += st.Id.ToString() + ", ";
                    }
                    staffonorder = staffonorder.TrimEnd([',', ' ']);



                    target.OrderList.Items.Add(new ListViewItem([ord.Id.ToString(),
                                                           ord.Table.ToString(),
                                                           ord.CreationTime.ToString(),
                                                           staffonorder,
                                                           StatusConverter.Do(ord.Status)]));
                }
            }
            public void Button1Function(object sender, EventArgs e)
            {
                //Установить официанта для заказа в БД либо снять официанта с заказа в БД
                UpdateThings();
            }
            public void Button2Function(object sender, EventArgs e)
            {
                //Удалить заказ/отметить как выполненный
                UpdateThings();
            }
            public void TableButtonFunction(object sender, EventArgs e)
            {
                //Установить официанта для заказа в БД
                UpdateThings();
            }
            public void OrderListSelectionChangeFunction(object sender, EventArgs e)
            {
                //Запросить информацию о стоимости заказа из БД и отобразить ее в EditedListView

                if (target.OrderList.SelectedItems.Count > 0)
                {
                    if (target.OrderList.SelectedItems[0].SubItems[3].Text == "")
                    {
                        target.button1.Text = "Взять заказ";
                        target.button1.Enabled = true;
                    }
                    else if (target.OrderList.SelectedItems[0].SubItems[3].Text == target.user.Id.ToString())
                    {
                        target.button1.Text = "Отказаться от заказа";
                        target.button1.Enabled = true;
                    }
                    else target.button1.Enabled = false;
                }
                else target.button1.Enabled = false;

                decimal sum = 0;
                foreach (ListViewItem it in target.EditedListView.Items)
                    sum += decimal.Parse(it.SubItems[2].Text.Substring(1));
                if (sum > 0) target.TopLabel.Text = "Итоговая стоимость заказа: $" + sum.ToString();
                else target.TopLabel.Text = """
                        Синий столик требует уборки. Зеленые столики ожидают свои заказы. Красные столики подзывают официанта.
                        Светлые цвета обозначают столики, принятые другими официантами. Нажмите на столик, чтобы принять на себя его обслуживание.
                        Столики, обслуживаемые вами, имеют красную обводку.
                        """;
            }
        }
    }
}
