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
    public partial class Staff_Information : Form
    {
        private bool isNew = true;
        public Staff_Information()
        {
            InitializeComponent();
        }
        private void Refresh()
        {
            isNew = true;

            idtxt.Text = "";
            nametxt.Text = "";
            addresstxt.Text = "";
            mobiletxt.Text = "+880";
            salarytxt.Text = "";
            posttxt.Text = "";
            post.Text = "";

            staffTable.ClearSelection();
        }
        private void LoadStaffInfo()
        {
            string query = "Select * from Staff";

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            staffTable.AutoGenerateColumns = false;
            staffTable.DataSource = dt;
            staffTable.Refresh();
            staffTable.ClearSelection();

            this.Refresh();
        }
        private void LoadSingleStaff()
        {
            string query = "Select * from Staff Where id = '" + idtxt.Text + "'";

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid Id");
                return;
            }

            isNew = false;

            idtxt.Text = dt.Rows[0]["id"].ToString();
            nametxt.Text = dt.Rows[0]["name"].ToString();
            addresstxt.Text = dt.Rows[0]["address"].ToString();
            salarytxt.Text = dt.Rows[0]["salary"].ToString();
            mobiletxt.Text = dt.Rows[0]["mobile"].ToString();
            posttxt.Text = dt.Rows[0]["post"].ToString();
        }
        private void newBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadStaffInfo();
        }
        private void Staff_Information_Load(object sender, EventArgs e)
        {
            LoadStaffInfo();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (isNew == true)
            {
                MessageBox.Show("Please load existing data first");
                return;
            }

            string query = "Delete from Staff Where id = '" + idtxt.Text + "'";

            if (DatabaseConnection.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Book Deleted");
                this.LoadStaffInfo();
                this.Refresh();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string id = this.idtxt.Text;
            string name = this.nametxt.Text;
            string address = this.addresstxt.Text;
            string mobile = Convert.ToString(this.mobiletxt.Text);
            string salary = Convert.ToString(this.salarytxt.Text);
            string post = this.posttxt.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(salary) || string.IsNullOrEmpty(post))
            {
                MessageBox.Show("Invalid/Insufficient information");
                return;
            }

            string query = "";

            if (isNew == true)
            {
                query = "INSERT into Staff(name,address,mobile,salary,post) Values ('" + name + "', '" + address + "', '" + mobile + "', " + salary + ", '" + post + "')";
                MessageBox.Show("Staff Information Successfully Inserted");
            }
            else
            {
                query = "UPDATE Staff SET name = '" + name + "', address = '" + address + "', salary = " + salary + ", mobile = '" + mobile + "', post = '" + post + "' WHERE id = '" + idtxt.Text + "'";
                MessageBox.Show("Staff Information Successfully Updated");
            }

            if (DatabaseConnection.ExecuteQuery(query) == true)
            {
                this.LoadStaffInfo();
                this.Refresh();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Manager_Panel mh = new Manager_Panel();
            this.Visible = false;
            mh.Visible = true;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login_Frame lf = new Login_Frame();
            this.Visible = false;
            lf.Visible = true;
        }

        private void staffTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = staffTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                idtxt.Text = id;
                this.LoadSingleStaff();
            }
        }


        private void Staff_Information_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void post_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string query = "Select * from Staff WHERE post = '" + post.SelectedItem + "'";

            DatabaseConnection.ExecuteQuery(query);

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            staffTable.AutoGenerateColumns = false;
            staffTable.DataSource = dt;
            staffTable.Refresh();
            staffTable.ClearSelection();

            this.Refresh();
        }
    }
}
