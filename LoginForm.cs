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
            this.Hide();
        }

        private void LoginAsStaff_Click(object sender, EventArgs e)
        {
            
        }
    }
}
