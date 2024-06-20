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
        public StaffForm(IFormstrat formstate)
        {
            InitializeComponent();
            strat = formstate;
            strat.TargetForm = this;
            strat.SetVisuals();
            strat.UpdateThings();
        }

        public IFormstrat strat;
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
            target.button2.Text = "Связаться со столиком";
            target.button2.Click += Button2Function;
            target.button2.Enabled = false;

            target.OrderList.SelectedIndexChanged += OrderListSelectionChangeFunction;
            target.EditedListView.SelectedIndexChanged += EditedListSelectionChangeFunction;

            foreach (Button btn in target.Controls)
                if (btn.Text.StartsWith("Столик ")) btn.Click += TableButtonFunction;

            target.TopLabel.Text = """
                    Информация о заказе появится здесь.
                """;
        }
        public void UpdateThings()
        {
            //Запросить обновление списка заказов
        }
        public void Button1Function(object sender, EventArgs e)
        { 
            //Поднять состояние готовности заказа
        }
        public void Button2Function(object sender, EventArgs e)
        {
            MessageBox.Show("Эта функция еще не введена!");
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
            //Запросить блюда в заказе
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
                        Светлые цвета обозначают столики, принятые другими официантами. Нажмите на столик, чтобы принять на себя его обслуживание.
                        Столики, обслуживаемые вами, имеют красную обводку.
                        """;
        }
        public void UpdateThings()
        {
            //Запросить обновление списка заказов
            //Обновить статус столиков
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
                else if (target.OrderList.SelectedItems[0].SubItems[3].Text == "WAITERCODE")
                {
                    target.button1.Text = "Отказаться от заказа";
                    target.button1.Enabled = true;
                }
                else target.button1.Enabled = false;
            } else target.button1.Enabled = false;

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
