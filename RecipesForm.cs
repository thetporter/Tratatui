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
    public partial class RecipesForm : Form
    {
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
            state = new AddState();
            state.Invoke();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            state = new EditState();
            state.Invoke();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить {listView1.SelectedItems[0].Text}? Это действие необратимо.",
                "Подтвердить удаление", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            { 
                //Удалить блюдо из БД
            }
        }

        public void UpdateLists()
        {
            //Запросить список блюд из БД
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
}
