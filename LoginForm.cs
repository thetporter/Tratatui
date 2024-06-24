using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Tratatui
{
    public partial class LoginForm : Form
    {
        public TratatuiContext Database;

        public LoginForm()
        {
            InitializeComponent();
            DB.Database.Database.EnsureCreated();
        }

        private void LoginAsGuest_Click(object sender, EventArgs e)
        {
            GuestForm guest = new GuestForm();
            guest.Show();
        }

        private void LoginAsStaff_Click(object sender, EventArgs e)
        {
            //Проверка на заполнение
            if (StaffCodeField.Text.Length < 1 || PasswordField.Text.Length < 1)
                MessageBox.Show("Введите код сотрудника и соответствующий пароль.");
            else
            {
                //Проверка на корректность кода
                int nowhere;
                if (!int.TryParse(StaffCodeField.Text, out nowhere))
                {
                    MessageBox.Show("Некорректный формат кода сотрудника.");
                    return;
                }

                //Поиск сотрудника
                Staff user = null;
                foreach (Staff st in DB.Database.Staff)
                {
                    if (st.Id == nowhere)
                    {
                        user = st; break;
                    }
                }
                if (user == null)
                {
                    MessageBox.Show($"Сотрудник с кодом {nowhere} не найден.");
                    return;
                }

                //Сравнение пароля
                if (user.PasswordHash != Encrypter.Encrypt(PasswordField.Text, Encrypter.Extract(user.PasswordHash)))
                {
                    MessageBox.Show("Неверный пароль.");
                    return;
                }

                StaffForm staff = new StaffForm(user);
                staff.Show();
            }
            
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count > 1)
            {
                switch (MessageBox.Show("Это окно требуется для работы приложения и не скрывается, т.к. может возникнуть необходимость открытия нескольких окон. Продолжить?", "Подтвердите выход", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes: break;
                    default: { e.Cancel = true; break; }
                }
            }
        }
    }

    public interface IUpdateable
    {
        public void UpdateInfo();
    }

    public static partial class DB
    {

        public static void UpdateAll()
        {
            foreach (IUpdateable form in Application.OpenForms.OfType<IUpdateable>())
            {
                    if (form != null && form is IUpdateable) form.UpdateInfo();
            }
        }
    }
}
