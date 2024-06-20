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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginAsGuest_Click(object sender, EventArgs e)
        {
            GuestForm guest = new GuestForm();
            guest.Show();
        }

        private void LoginAsStaff_Click(object sender, EventArgs e)
        {
            //Проверить данные сотрудника в БД; Получить его статус и передать форме staff
            StaffForm staff = new StaffForm(new WaiterStrategy());
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count > 1)
            {
                switch (MessageBox.Show("Это окно требуется для работы приложения и не скрывается, т.к. может возникнуть необходимость открытия нескольких окон. Продолжить?", "Подтвердите выход", MessageBoxButtons.OKCancel))
                {
                    case DialogResult.OK: break;
                    default: { e.Cancel = true; break; }
                }
            }
        }
    }
}
