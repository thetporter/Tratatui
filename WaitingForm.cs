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
    public partial class WaitingForm : Form, IUpdateable
    {
        public GuestForm guestForm;
        public Order awaitedorder;

        public WaitingForm()
        {
            InitializeComponent();
        }

        private void EditOrderButton_Click(object sender, EventArgs e)
        {
            awaitedorder = DB.Database.Orders.Find(awaitedorder.Id);
            DB.Database.Orders.Remove(awaitedorder);
            DB.Database.SaveChanges();
            DB.UpdateAll();
            guestForm.Enabled = true;
            this.Close();
        }

        private void CancelOrderButton_Click(object sender, EventArgs e)
        {
            awaitedorder = DB.Database.Orders.Find(awaitedorder.Id);
            DB.Database.Orders.Remove(awaitedorder);
            DB.Database.SaveChanges();
            DB.UpdateAll();
            this.Close();
            guestForm.Close();
        }

        private void CallWaiterButton_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Status = 0;
            order.Active = true;
            order.Type = OrderType.Request;
            order.Table = guestForm.table;
            guestForm.Enabled = false;
        }

        public void UpdateInfo()
        {
            awaitedorder = DB.Database.Orders.Find(awaitedorder.Id);
            if (awaitedorder is null) return;
            this.NumberLabel.Text = awaitedorder.Id.ToString();
            this.StateLabel.Text = StatusConverter.Do(awaitedorder.Status);
            Staff temp = DB.Database.Staff.Include(e => e.Orders).ToList().Find(st => { return st.Orders.Contains(awaitedorder); });
            if (temp is null) this.WaiterLabel.Text = "(не назначен)"; else this.WaiterLabel.Text = temp.Name;
        }

        private void WaitingForm_Load(object sender, EventArgs e)
        {
            this.NumberLabel.Text = awaitedorder.Id.ToString();
            this.StateLabel.Text = StatusConverter.Do(awaitedorder.Status);
            Staff temp = DB.Database.Staff.Include(e => e.Orders).ToList().Find(st => { return st.Orders.Contains(awaitedorder); });
            if (temp is null) this.WaiterLabel.Text = "(не назначен)"; else this.WaiterLabel.Text = temp.Name;
        }
    }
}
