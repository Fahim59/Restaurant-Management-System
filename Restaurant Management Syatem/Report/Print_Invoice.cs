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
using Microsoft.Reporting.WinForms;

namespace Restaurant_Management_Syatem.Report
{
    public partial class Print_Invoice : Form
    {
        string invoiceId;
        public Print_Invoice()
        {
            InitializeComponent();
        }
        public Print_Invoice(string id)
        {
            invoiceId = id;
            InitializeComponent();
            this.printBtn.Visible = false;
            this.idtxt.Visible = false;
            this.inlabel.Text = "Invoice Slip";
            this.inlabel.Location = new Point(265, 7);
            this.inlabel.Font = new Font("Comic Sans MS", 14, FontStyle.Bold);
        }

        private void Print_Invoice_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MUSTAFIZ\FAHIMSQL;Initial Catalog=restaurant;Integrated Security=True");

            SqlDataAdapter sda = new SqlDataAdapter("Select * from View_Bill where pid = '" + invoiceId + "'", con);

            DataSet1 ds = new DataSet1();
            sda.Fill(ds, "DataTable1");

            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);

            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = @"F:\C# Code\Restaurant Management Syatem\Restaurant Management Syatem\Report\Invoice.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MUSTAFIZ\FAHIMSQL;Initial Catalog=restaurant;Integrated Security=True");

            SqlDataAdapter sda = new SqlDataAdapter("Select * from View_Bill where pid = '" + idtxt.Text + "'", con);

            DataSet1 ds = new DataSet1();
            sda.Fill(ds, "DataTable1");

            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);

            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = @"F:\C# Code\Restaurant Management Syatem\Restaurant Management Syatem\Report\Invoice.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
