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
    public partial class Contract_Us : Form
    {
        public Contract_Us()
        {
            InitializeComponent();
        }

        private void Contract_Us_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login_Frame lf = new Login_Frame();
            lf.Visible = true;
            this.Visible = false;
        }
    }
}
