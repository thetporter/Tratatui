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
    public partial class WaitingForm : Form, IUpdateable
    {
        public GuestForm guestForm;

        public WaitingForm()
        {
            InitializeComponent();
        }

        private void EditOrderButton_Click(object sender, EventArgs e)
        {
            guestForm.Enabled = true;
            this.Close();
        }

        private void CancelOrderButton_Click(object sender, EventArgs e)
        {
            //Найти и удалить заказ в БД
            this.Close();
            guestForm.Close();
        }

        private void CallWaiterButton_Click(object sender, EventArgs e)
        {
            //Создать заказ на вызов официанта в БД
            (sender as Control).Enabled = false;
        }

        public void UpdateInfo()
        {

        }
    }
}
