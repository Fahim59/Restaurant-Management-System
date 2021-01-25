using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Restaurant_Management_Syatem
{
    public partial class Customer_Panel : Form
    {
        private bool isNew = true;
        public Customer_Panel()
        {
            InitializeComponent();
        }
        private void Refresh()
        {
            isNew = true;

            nametxt.Text = "";
            category.Text = "";
            pricetxt.Text = "";
            qttxt.Text = "";
            totaltxt.Text = "";
            subtxt.Text = "0";
            vattxt.Text = "5";
            nettxt.Text = "";
            paytype.Text = "";
            cname.Text = "";
            mobiletxt.Text = "";
            addresstxt.Text = "";

            orderTable.ClearSelection();
        }

        private void LoadSingleItem()
        {
            string query = "Select itemName,price from Food_Item Where itemName = '" + nametxt.Text + "'";

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid Id");
                return;
            }

            isNew = false;

            nametxt.Text = dt.Rows[0]["itemName"].ToString();
            pricetxt.Text = dt.Rows[0]["price"].ToString();

            totaltxt.Text = "";
            qttxt.Text = "";
        }

        private void orderTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string name = orderTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                nametxt.Text = name;
                this.LoadSingleItem();
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
            orderView.Items.Clear();
            orderTable.DataSource = null;
        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "Select * from Food_Item WHERE category = '" + category.SelectedItem + "'";

            DatabaseConnection.ExecuteQuery(query);

            DataTable dt = DatabaseConnection.GetData(query);

            if (dt == null)
                return;

            orderTable.AutoGenerateColumns = false;
            orderTable.DataSource = dt;
            orderTable.Refresh();
            orderTable.ClearSelection();

            this.Refresh();
        }

        private void Customer_Panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            if (orderView.Items.Count > 0)
            {
                string subTotal = this.subtxt.Text;
                string vat = this.vattxt.Text;
                string total = this.nettxt.Text;
                string cName = this.cname.Text;
                string mobile = this.mobiletxt.Text;
                string address = this.addresstxt.Text;
                string paytype = this.paytype.Text;


                if (string.IsNullOrEmpty(subTotal) || string.IsNullOrEmpty(vat) || string.IsNullOrEmpty(total) || string.IsNullOrEmpty(paytype) || string.IsNullOrEmpty(cName) || string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(address))
                {
                    MessageBox.Show("Invalid/Insufficient information");
                    return;
                }
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=MUSTAFIZ\FAHIMSQL;Initial Catalog=restaurant;Integrated Security=True");
                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "INSERT into Order_Print(date) Values" + "(getdate()) select SCOPE_IDENTITY()";

                    string invoiceId = cmd.ExecuteScalar().ToString();

                    foreach (ListViewItem ListItem in orderView.Items)
                    {
                        cmd.CommandText = "INSERT into Details_Order(pid,itemName,price,quantity,total,subtotal,cName,mobile,address,payType) Values" + "(" + invoiceId + ",'" + ListItem.SubItems[0].Text + "', '" + ListItem.SubItems[1].Text + "', '" + ListItem.SubItems[2].Text + "', '" + ListItem.SubItems[3].Text + "'," + total + ", '" + cName + "', '" + mobile + "', '" + address + "', '" + paytype + "')";
                        cmd.ExecuteNonQuery();
                    }

                    con.Close();

                    MessageBox.Show("Invoice Successfully Inserted with InvoiceID: " + invoiceId);

                    new Report.Print_Invoice(invoiceId).Show();

                    this.Refresh();
                    orderView.Items.Clear();
                    orderTable.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Atleast 1 item must be added in the cart");
            }
        }

        private void cartBtn_Click(object sender, EventArgs e)
        {
            if (qttxt.Text == "")
            {
                MessageBox.Show("Enter Quantity");
                qttxt.Focus();
                return;
            }
            else if (isNew == true)
            {
                MessageBox.Show("Choose any Item");
                return;
            }

            string[] ar = new string[4];
            ar[0] = nametxt.Text;
            ar[1] = pricetxt.Text;
            ar[2] = qttxt.Text;
            ar[3] = totaltxt.Text;

            ListViewItem lvi = new ListViewItem(ar);

            for (int i = orderView.Items.Count - 1; i >= 0; i--)
            {
                if (orderView.Items[i].ToString().ToLower().Contains(nametxt.Text.ToLower()))
                {
                    orderView.Items[i].SubItems[2].Text = (Convert.ToInt32(orderView.Items[i].SubItems[2].Text) + Convert.ToInt32(qttxt.Text)).ToString();
                    orderView.Items[i].SubItems[3].Text = (Convert.ToInt32(orderView.Items[i].SubItems[2].Text) * Convert.ToInt32(pricetxt.Text)).ToString();
                    Refresh();
                    return;
                }
            }
            orderView.Items.Add(lvi);
            Refresh();
        }
        private void Check()
        {
            for (int i = orderView.Items.Count - 1; i >= 0; i--)
            {
                ListViewItem item = orderView.Items[i];

                if (item.SubItems[2].Text == "0")
                {
                    item.Remove();
                }
            }
        }

        private void increaseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (orderView.SelectedItems != null)
                {
                    ListViewItem item = orderView.SelectedItems[0];
                    item.SubItems[2].Text = (Convert.ToInt32(item.SubItems[2].Text) + Convert.ToInt32(1)).ToString();
                    item.SubItems[3].Text = (Convert.ToInt32(item.SubItems[1].Text) * Convert.ToInt32(item.SubItems[2].Text)).ToString();

                    orderView.SelectedItems.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select an Item");
            }
        }

        private void decreaseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (orderView.SelectedItems != null)
                {
                    ListViewItem item = orderView.SelectedItems[0];

                    if (item.SubItems[2].Text == "0")
                    {
                        item.SubItems[2].Text = "0";
                        return;
                    }
                    item.SubItems[2].Text = (Convert.ToInt32(item.SubItems[2].Text) - Convert.ToInt32(1)).ToString();
                    item.SubItems[3].Text = (Convert.ToInt32(item.SubItems[1].Text) * Convert.ToInt32(item.SubItems[2].Text)).ToString();

                    orderView.SelectedItems.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select an Item");
            }
        }

        private void remBtn_Click(object sender, EventArgs e)
        {
            if (orderView.SelectedItems.Count > 0)
            {
                for (int i = 0; i < orderView.Items.Count; i++)
                {
                    if (orderView.Items[i].Selected)
                    {
                        subtxt.Text = (Convert.ToInt32(subtxt.Text) - Convert.ToInt32(orderView.Items[i].SubItems[3].Text)).ToString();
                        orderView.Items[i].Remove();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select an Item");
            }
        }

        private void qttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (qttxt.Text.Length > 0)
                {
                    totaltxt.Text = (Convert.ToInt32(pricetxt.Text) * Convert.ToInt32(qttxt.Text)).ToString();
                    orderTable.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Integer Only!");
                qttxt.Text = "";
                qttxt.Focus();
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            qttxt.Text = "";
            qttxt.Focus();
        }

        private void subBtn_Click(object sender, EventArgs e)
        {
            Check();

            double sum = 0;
            foreach (ListViewItem lstItem in orderView.Items)
            {
                sum += double.Parse(lstItem.SubItems[3].Text);
                subtxt.Text = sum.ToString();
            }
            double vat = Convert.ToDouble(vattxt.Text)/100;
            double total = sum + (sum * vat);
            nettxt.Text = total.ToString();
        }
    }
}
