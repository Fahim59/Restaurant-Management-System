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
    public partial class Restaurant_Expense : Form
    {
        private bool isNew = true;
        public Restaurant_Expense()
        {
            InitializeComponent();
        }
        private void Refresh()
        {
            isNew = true;

            idtxt.Text = "";
            nametxt.Text = "";
            cattxt.Text = "";
            pricetxt.Text = "";
            cattxt.Text = "";
            category.Text = "";

            exTable.ClearSelection();
        }
        private void LoadExpenseInfo()
        {
            string query = "Select * from Expense";

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            exTable.AutoGenerateColumns = false;
            exTable.DataSource = dt;
            exTable.Refresh();
            exTable.ClearSelection();

            this.Refresh();
        }
        private void LoadSingleExpense()
        {
            string query = "Select * from Expense Where serialNo = '" + idtxt.Text + "'";

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid Id");
                return;
            }

            isNew = false;

            idtxt.Text = dt.Rows[0]["serialNo"].ToString();
            nametxt.Text = dt.Rows[0]["name"].ToString();
            cattxt.Text = dt.Rows[0]["type"].ToString();
            pricetxt.Text = dt.Rows[0]["amount"].ToString();
        }
        private void newBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadExpenseInfo();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (isNew == true)
            {
                MessageBox.Show("Please load existing data first");
                return;
            }

            string query = "Delete from Expense Where serialNo = '" + idtxt.Text + "'";

            if (DatabaseConnection.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Expense Deleted");
                this.LoadExpenseInfo();
                this.Refresh();
            }
        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "Select * from Expense WHERE type = '" + category.SelectedItem + "'";

            DatabaseConnection.ExecuteQuery(query);

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            exTable.AutoGenerateColumns = false;
            exTable.DataSource = dt;
            exTable.Refresh();
            exTable.ClearSelection();

            this.Refresh();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string id = this.idtxt.Text;
            string name = this.nametxt.Text;
            string category = this.cattxt.Text;
            string price = this.pricetxt.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Invalid/Insufficient information");
                return;
            }

            string query = "";

            if (isNew == true)
            {
                query = "INSERT into Expense(name,type,amount,date) Values ('" + name + "', '" + category + "','" + price + "',GetDate())";
                MessageBox.Show("Expense Information Successfully Inserted");
            }
            else
            {
                query = "UPDATE Expense SET name = '" + name + "', type = '" + category + "', amount = " + price + " WHERE serialNo = '" + idtxt.Text + "'";
                MessageBox.Show("Expense Information Successfully Updated");
            }

            if (DatabaseConnection.ExecuteQuery(query) == true)
            {
                this.LoadExpenseInfo();
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
        private void exTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = exTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                idtxt.Text = id;
                this.LoadSingleExpense();
            }
        }
        private void Restaurant_Expense_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Restaurant_Expense_Load(object sender, EventArgs e)
        {
            LoadExpenseInfo();
            cattxt.Text = "";
        }
    }
}
