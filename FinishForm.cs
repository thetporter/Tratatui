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
    public partial class FinishForm : Form
    {
        public Table table;
        public List<Form> toClose = new List<Form>();

        public FinishForm(Table table)
        {
            InitializeComponent();
            this.table = table;
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            Order clean = new Order();
                clean.Status = 0;
                clean.Active = true;
                clean.Table = table;
                clean.CreationTime = TimeOnly.Parse(DateTime.Now.TimeOfDay.ToString());
                clean.Type = OrderType.Cleanup;
            DB.Database.Orders.Add(clean);

            table.State = TableState.Finished;
            DB.Database.SaveChanges();

            foreach (Form f in toClose) { f.Close(); }
            this.Close();

            
            DB.UpdateAll();
        }
    }
}
