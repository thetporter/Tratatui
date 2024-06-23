using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tratatui;

namespace Tratatui
{
    public partial class RecipesForm : Form
    {
        public int StoredId;
        public IEditingState state;

        public RecipesForm()
        {
            InitializeComponent();
        }

        private void DishDescription_MouseHover(object sender, EventArgs e)
        {
            DescTooltip.SetToolTip(DishDescription, DishDescription.Text);
            DescTooltip.Active = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (state is InactiveState)
            {
                state = new AddState();
                state.Invoke();
            }
            else if (state is AdminInactiveState)
            {
                state = new AdminAddState();
                state.Invoke();
            }
            
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (state is InactiveState)
            {
                state = new EditState();
                state.Invoke();
            }
            else if (state is AdminInactiveState)
            {
                state = new AdminEditState();
                state.Invoke();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (state is InactiveState)
            {
                if (MessageBox.Show($"Вы точно хотите удалить {listView1.SelectedItems[0].Text}? Это действие необратимо.",
                    "Подтвердить удаление", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    //Удалить блюдо из БД
                }
            } else if (state is AdminInactiveState)
            {
                if (MessageBox.Show($"Вы точно хотите удалить пользователя с кодом {listView1.SelectedItems[0].Text}? Это действие необратимо.",
                    "Подтвердить удаление", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    //Удалить запись сотрудника из БД
                }
            }
        }

        public void UpdateLists()
        {
            if (state is InactiveState)
            {
                //Запросить список блюд из БД
            } else if (state is AdminInactiveState)
            {
                //Запросить список сотрудников из БД
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            state.IndexChangeFunction();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            state.ConfirmFunction();
        }
    }

    public interface IEditingState
    {
        public RecipesForm target { get; set; }
        public void Invoke();
        public void ConfirmFunction();
        public void IndexChangeFunction();
    }

    public class AddState : IEditingState
    {
        public RecipesForm target { get; set; }
        public void Invoke()
        {
            target.AddButton.Enabled = false;
            target.EditButton.Enabled = false;
            target.DeleteButton.Enabled = false;

            target.ConfirmButton.Visible = true;
            target.NameTextbox.Visible = true;
            target.DescTextbox.Visible = true;
            target.RecipeTextbox.Visible = true;
            target.PriceBox.Visible = true;
            target.label1.Visible = true;

            target.RecipeBox.Visible = false;

            target.listView1.SelectedItems.Clear();

            target.NameTextbox.Text = String.Empty;
            target.DescTextbox.Text = String.Empty;
            target.RecipeTextbox.Text = String.Empty;
            target.PriceBox.Text = String.Empty;
        }

        public void ConfirmFunction()
        {
            if (target.NameTextbox.Text.Trim().Length < 1 ||
                target.DescTextbox.Text.Trim().Length < 1 ||
                target.RecipeTextbox.Text.Trim().Length < 1)
                MessageBox.Show("Неверное заполнение информации о блюде! Блюдо должно иметь название, описание и рецепт.");
            //Создание блюда в БД
            target.state = new InactiveState();
            target.state.Invoke();
        }

        public void IndexChangeFunction()
        {
            if (target.listView1.SelectedItems.Count == 0)
            {
                target.DishName.Text = "Название блюда";
                target.DishDescription.Text = "Описание блюда";
                target.RecipeBox.Items.Clear();
                target.RecipeBox.Items.Add("Рецепт блюда");
            }
            target.state = new InactiveState();
            target.state.Invoke();
        }
    }

    public class EditState : IEditingState
    {
        public RecipesForm target { get; set; }
        public void Invoke()
        {
            target.AddButton.Enabled = false;
            target.EditButton.Enabled = false;
            target.DeleteButton.Enabled = false;

            target.ConfirmButton.Visible = true;
            target.NameTextbox.Visible = true;
            target.DescTextbox.Visible = true;
            target.RecipeTextbox.Visible = true;
            target.PriceBox.Visible = true;
            target.label1.Visible = true;

            target.RecipeBox.Visible = false;

            target.NameTextbox.Text = target.DishName.Text;
            target.DescTextbox.Text = target.DishDescription.Text;
            string recipe = "";
            foreach (var item in target.RecipeBox.Items) recipe += item.ToString() + "\n";
            target.RecipeTextbox.Text = recipe;
            target.PriceBox.Text = target.listView1.SelectedItems[0].SubItems[1].Text.Substring(1);
        }

        public void ConfirmFunction()
        {
            if (target.NameTextbox.Text.Trim().Length < 1 ||
                target.DescTextbox.Text.Trim().Length < 1 ||
                target.RecipeTextbox.Text.Trim().Length < 1)
                MessageBox.Show("Неверное заполнение информации о блюде! Блюдо должно иметь название, описание и рецепт.");
            //Изменение блюда в БД
            target.state = new InactiveState();
            target.state.Invoke();
        }

        public void IndexChangeFunction()
        {
            //Сброс режима
            target.state = new InactiveState();
            target.state.Invoke();
        }
    }

    public class InactiveState : IEditingState
    {
        public RecipesForm target { get; set; }
        public void Invoke()
        {
            target.AddButton.Enabled = true;
            target.EditButton.Enabled = false;
            target.DeleteButton.Enabled = false;

            target.ConfirmButton.Visible = false;
            target.NameTextbox.Visible = false;
            target.DescTextbox.Visible = false;
            target.RecipeTextbox.Visible = false;
            target.PriceBox.Visible = false;
            target.label1.Visible = false;

            target.RecipeBox.Visible = true;

            target.UpdateLists();
        }

        public void ConfirmFunction()
        {
            //Недостижимо
            return;
        }

        public void IndexChangeFunction()
        {
            if (target.listView1.SelectedItems.Count == 0)
            {
                target.DishName.Text = "Название блюда";
                target.DishDescription.Text = "Описание блюда";
                target.RecipeBox.Items.Clear();
                target.RecipeBox.Items.Add("Рецепт блюда");

                target.EditButton.Enabled = false;
                target.DeleteButton.Enabled = false;
            } else
            {
                //Запрос и выведение информации о блюде
                target.DishName.Text = "Название блюда";
                target.DishDescription.Text = "Описание блюда";
                target.RecipeBox.Items.Clear();
                target.RecipeBox.Items.Add("Рецепт блюда");

                target.EditButton.Enabled = true;
                target.DeleteButton.Enabled = true;
            }
        }
    }


    public class AdminAddState : IEditingState
    {
        public RecipesForm target { get; set; }
        public void Invoke()
        {
            target.AddButton.Enabled = false;
            target.EditButton.Enabled = false;
            target.DeleteButton.Enabled = false;

            target.ConfirmButton.Visible = true;
            target.NameTextbox.Visible = true;
            target.DescTextbox.Visible = false;
            target.RecipeTextbox.Visible = false;
            target.PriceBox.Visible = false;
            target.label1.Visible = false;
            target.StaffTypeBox.Visible = true;

            target.RecipeBox.Visible = false;

            target.listView1.SelectedItems.Clear();

            target.NameTextbox.Text = String.Empty;
            target.DescTextbox.Text = String.Empty;
            target.RecipeTextbox.Text = String.Empty;
            target.PriceBox.Text = String.Empty;
        }

        public void ConfirmFunction()
        {
            if (target.NameTextbox.Text.Trim().Length < 1)
                MessageBox.Show("Неверное заполнение информации о сотруднике!");
            //Создание сотрудника в БД
            target.state = new InactiveState();
            target.state.Invoke();
        }

        public void IndexChangeFunction()
        {
            if (target.listView1.SelectedItems.Count == 0)
            {
                target.DishName.Text = "Имя и фамилия сотрудника";
                target.DishDescription.Text = "Код сотрудника: --";
                target.RecipeBox.Items.Clear();
                target.RecipeBox.Items.Add("Заказы, принятые и выполненные сотрудником");
            }
            target.state = new InactiveState();
            target.state.Invoke();
        }
    }   

    public class AdminEditState : IEditingState
    {
        public RecipesForm target { get; set; }
        public void Invoke()
        {
            target.AddButton.Enabled = false;
            target.EditButton.Enabled = false;
            target.DeleteButton.Enabled = false;

            target.ConfirmButton.Visible = true;
            target.NameTextbox.Visible = true;
            target.DescTextbox.Visible = false;
            target.RecipeTextbox.Visible = false;
            target.PriceBox.Visible = false;
            target.label1.Visible = false;
            target.StaffTypeBox.Visible = true;

            target.RecipeBox.Visible = false;

            target.NameTextbox.Text = target.DishName.Text;
            target.StaffTypeBox.SelectedIndex = StaffTypeConverter.StringToInt(target.listView1.SelectedItems[0].SubItems[2].Text);
        }

        public void ConfirmFunction()
        {
            if (target.NameTextbox.Text.Trim().Length < 1)
                MessageBox.Show("Неверное заполнение информации! Сотрудник должен иметь имя.");
            //Изменение сотрудника в БД
            target.state = new AdminInactiveState();
            target.state.Invoke();
        }

        public void IndexChangeFunction()
        {
            //Сброс режима
            target.DishName.Text = "Имя и фамилия сотрудника";
            target.DishDescription.Text = "Код сотрудника: --";
            target.RecipeBox.Items.Clear();
            target.RecipeBox.Items.Add("Заказы, принятые и выполненные сотрудником");
            target.state = new AdminInactiveState();
            target.state.Invoke();
        }
    }

    public class AdminInactiveState : IEditingState
    {
        public RecipesForm target { get; set; }
        public void Invoke()
        {
            target.AddButton.Enabled = true;
            target.EditButton.Enabled = false;
            target.DeleteButton.Enabled = false;

            target.ConfirmButton.Visible = false;
            target.NameTextbox.Visible = false;
            target.DescTextbox.Visible = false;
            target.RecipeTextbox.Visible = false;
            target.PriceBox.Visible = false;
            target.label1.Visible = false;
            target.StaffTypeBox.Visible = false;

            target.RecipeBox.Visible = true;

            target.DishName.Text = "Имя и фамилия сотрудника";
            target.DishDescription.Text = "Код сотрудника: --";
            target.RecipeBox.Items.Clear();
            target.RecipeBox.Items.Add("Заказы, принятые и выполненные сотрудником");

            target.listView1.Columns.Clear();
            target.listView1.Columns.Add("Код");
            target.listView1.Columns.Add("Имя");
            target.listView1.Columns.Add("Должность");

            target.UpdateLists();
        }

        public void ConfirmFunction()
        {
            //Недостижимо
            return;
        }

        public void IndexChangeFunction()
        {
            if (target.listView1.SelectedItems.Count == 0)
            {
                target.DishName.Text = "Имя сотрудника";
                target.DishDescription.Text = "Код сотрудника: --";
                target.RecipeBox.Items.Clear();
                target.RecipeBox.Items.Add("Заказы, принятые и выполненные сотрудником");

                target.EditButton.Enabled = false;
                target.DeleteButton.Enabled = false;
            }
            else
            {
                //Запрос и выведение информации о сотруднике
                target.DishName.Text = "Имя";
                target.DishDescription.Text = "Код";
                target.RecipeBox.Items.Clear();
                //foreach (Order o in Staff.Orders)
                //{
                //    target.RecipeBox.Items.Add("Рецепт блюда");
                //}

                target.StoredId = int.Parse(target.listView1.SelectedItems[0].Text);

                target.EditButton.Enabled = true;
                target.DeleteButton.Enabled = true;
            }
        }
    }

    public static class StaffTypeConverter
    {
        public static StaffType IntToType (int index)
        {
            switch (index)
            {
                case 1: return StaffType.Chef;
                case 2: return StaffType.Admin;
                default: return StaffType.Waiter;
            }
        }

        public static int TypeToInt (StaffType type)
        {
            switch (type)
            {
                case StaffType.Chef: return 1;
                case StaffType.Admin: return 2;
                default: return 0;
            }
        }

        public static string TypeToString(StaffType type) 
        {
            switch (type)
            {
                case StaffType.Chef: return "Повар";
                case StaffType.Admin: return "Администратор";
                default: return "Официант";
            }
        }

        public static StaffType StringToType (string input)
        {
            switch (input)
            {
                case "Повар": return StaffType.Chef;
                case "Администратор": return StaffType.Admin;
                default: return StaffType.Waiter;
            }
        }

        public static string IntToString (int index)
        {
            switch (index)
            {
                case 1: return "Повар";
                case 2: return "Администратор";
                default: return "Официант";
            }
        }

        public static int StringToInt(string input)
        {
            switch (input)
            {
                case "Повар": return 1;
                case "Администратор": return 2;
                default: return 0;
            }
        }
    }
}
