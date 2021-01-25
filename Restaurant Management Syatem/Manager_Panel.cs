using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_Syatem
{
    public partial class Manager_Panel : Form
    {
        public Manager_Panel()
        {
            InitializeComponent();
        }

        private void employeeBtn_Click(object sender, EventArgs e)
        {
            Staff_Information sf = new Staff_Information();
            this.Hide();
            sf.Show();
        }

        private void expenseBtn_Click(object sender, EventArgs e)
        {
            Restaurant_Expense re = new Restaurant_Expense();
            this.Hide();
            re.Show();
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            Order_List ol = new Order_List();
            this.Hide();
            ol.Show();
        }

        private void invoiceBtn_Click(object sender, EventArgs e)
        {
            new Report.Print_Invoice().Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login_Frame lf = new Login_Frame();
            lf.Visible = true;
            this.Visible = false;
        }

        private void Manager_Panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void foodBtn_Click(object sender, EventArgs e)
        {
            Food_Management fm = new Food_Management();
            fm.Visible = true;
            this.Visible = false;
        }

        private void emailBtn_Click(object sender, EventArgs e)
        {
            Email em = new Email();
            this.Hide();
            em.Show();
        }
    }
}
