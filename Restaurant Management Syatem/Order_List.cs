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
    public partial class Order_List : Form
    {
        private bool isNew = true;
        public Order_List()
        {
            InitializeComponent();
        }
        private void Refresh()
        {
            isNew = true;

            idtxt.Text = "";
            nametxt.Text = "";
            pricetxt.Text = "";
            qntxt.Text = "";
            totaltxt.Text = "";
            cnametxt.Text = "";
            mobiletxt.Text = "";
            addresstxt.Text = "";
            paytypetxt.Text = "";

            orderTable.ClearSelection();
        }
        private void LoadOrderInfo()
        {
            string query = "Select * from View_Bill";

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            orderTable.AutoGenerateColumns = false;
            orderTable.DataSource = dt;
            orderTable.Refresh();
            orderTable.ClearSelection();

            this.Refresh();
        }
        private void LoadSingleOrder()
        {
            string query = "Select * from View_Bill Where pid = '" + idtxt.Text + "'";

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid Id");
                return;
            }

            isNew = false;

            idtxt.Text = dt.Rows[0]["pid"].ToString();
            nametxt.Text = dt.Rows[0]["itemName"].ToString();
            pricetxt.Text = dt.Rows[0]["price"].ToString();
            qntxt.Text = dt.Rows[0]["quantity"].ToString();
            cnametxt.Text = dt.Rows[0]["cName"].ToString();
            mobiletxt.Text = dt.Rows[0]["mobile"].ToString();
            addresstxt.Text = dt.Rows[0]["address"].ToString();
            totaltxt.Text = dt.Rows[0]["total"].ToString();
            paytypetxt.Text = dt.Rows[0]["payType"].ToString();
        }
        private void newBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadOrderInfo();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (isNew == true)
            {
                MessageBox.Show("Please load existing data first");
                return;
            }

            string query = "Delete from View_Bill Where pid = '" + idtxt.Text + "'";

            if (DatabaseConnection.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Expense Deleted");
                this.LoadOrderInfo();
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

        private void orderTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = orderTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                idtxt.Text = id;
                this.LoadSingleOrder();
            }
        }

        private void Order_List_Load(object sender, EventArgs e)
        {
            LoadOrderInfo();
        }

        private void Order_List_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
