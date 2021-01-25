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
    public partial class Login_Frame : Form
    {
        public Login_Frame()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(usertxt.Text == "a001" && passtxt.Text == "admin")
            {
                Manager_Panel mp = new Manager_Panel();
                mp.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Invaild Id or Password");
            }
        }

        private void csBtn_Click(object sender, EventArgs e)
        {
            Customer_Panel cp = new Customer_Panel();
            this.Hide();
            cp.Show();
        }

        private void Login_Frame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void contracttxt_Click(object sender, EventArgs e)
        {
            Contract_Us cu = new Contract_Us();
            cu.Visible = true;
            this.Visible = false;

        }
    }
}
