using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Web;

namespace Restaurant_Management_Syatem
{
    public partial class Email : Form
    {
        public Email()
        {
            InitializeComponent();
        }

        private void Email_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void emailBtn_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage(fromtxt.Text, totxt.Text, subjecttxt.Text, bodytxt.Text);  //Represents an email message that can be sent using the SmtpClient class
                SmtpClient client = new SmtpClient(servertxt.Text);  //It is a class which allows applications to send email by using SMTP(Simple Mail Transfer Protocol); Smtp Server = smtp.company.com ; >> Gmail = smtp.gmail.com; Yahoo = smtp.yahoo.com

                mail.Attachments.Add(new Attachment(attxt.Text));  //The Attachment class is used with the MailMessage class.

                client.Port = 587;  //Port 587 is the preffered port for submitting emails, Port 25 is widely abused by Malware as a result many ISPs are restricting its use.
                client.Credentials = new System.Net.NetworkCredential(usertxt.Text, passtxt.Text);  //It is a class which is used to provide the credinals to send an email. Port 587 allows to use a SSL connection
                client.EnableSsl = true;
                client.Send(mail);

                MessageBox.Show("Email Send Successfully");

                totxt.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void attachBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string picPath = ofd.FileName.ToString();
                attxt.Text = picPath;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Manager_Panel mp = new Manager_Panel();
            this.Hide();
            mp.Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login_Frame lf = new Login_Frame();
            this.Hide();
            lf.Show();
        }
    }
}
