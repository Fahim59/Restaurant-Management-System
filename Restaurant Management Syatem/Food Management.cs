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
    public partial class Food_Management : Form
    {
        private bool isNew = true;
        public Food_Management()
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

            foodTable.ClearSelection();
        }
        private void LoadFoodInfo()
        {
            string query = "Select * from Food_Item";

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            foodTable.AutoGenerateColumns = false;
            foodTable.DataSource = dt;
            foodTable.Refresh();
            foodTable.ClearSelection();

            this.Refresh();
        }
        private void LoadSingleFood()
        {
            string query = "Select * from Food_Item Where itemId = '" + idtxt.Text + "'";

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid Id");
                return;
            }

            isNew = false;

            idtxt.Text = dt.Rows[0]["itemId"].ToString();
            nametxt.Text = dt.Rows[0]["itemName"].ToString();
            cattxt.Text = dt.Rows[0]["category"].ToString();
            pricetxt.Text = dt.Rows[0]["price"].ToString();
        }
        private void newBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadFoodInfo();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (isNew == true)
            {
                MessageBox.Show("Please load existing data first");
                return;
            }

            string query = "Delete from Food_Item Where itemId = '" + idtxt.Text + "'";

            if (DatabaseConnection.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Food_Item Deleted");
                this.LoadFoodInfo();
                this.Refresh();
            }
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
                query = "INSERT into Food_Item(itemName,category,price) Values ('" + name + "', '" + category + "','" + price + "')";
                MessageBox.Show("Food Information Successfully Inserted");
            }
            else
            {
                query = "UPDATE Food_Item SET itemName = '" + name + "', category = '" + category + "', price = " + price + " WHERE itemId = '" + idtxt.Text + "'";
                MessageBox.Show("Food Information Successfully Updated");
            }

            if (DatabaseConnection.ExecuteQuery(query) == true)
            {
                this.LoadFoodInfo();
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

        private void foodTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = foodTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                idtxt.Text = id;
                this.LoadSingleFood();
            }
        }

        private void Food_Management_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Food_Management_Load(object sender, EventArgs e)
        {
            LoadFoodInfo();
            cattxt.Text = "";
        }

        private void category_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string query = "Select * from Food_Item WHERE category = '" + category.SelectedItem + "'";

            DatabaseConnection.ExecuteQuery(query);

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            foodTable.AutoGenerateColumns = false;
            foodTable.DataSource = dt;
            foodTable.Refresh();
            foodTable.ClearSelection();

            this.Refresh();
        }
    }
}
