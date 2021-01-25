namespace Restaurant_Management_Syatem
{
    partial class Manager_Panel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.employeeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.foodBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.emailBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Peru;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeBtn,
            this.foodBtn,
            this.expenseBtn,
            this.reportBtn,
            this.invoiceBtn,
            this.emailBtn,
            this.logoutBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(145, 352);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // employeeBtn
            // 
            this.employeeBtn.Name = "employeeBtn";
            this.employeeBtn.Size = new System.Drawing.Size(132, 27);
            this.employeeBtn.Text = "Manage Staffs";
            this.employeeBtn.Click += new System.EventHandler(this.employeeBtn_Click);
            // 
            // foodBtn
            // 
            this.foodBtn.Name = "foodBtn";
            this.foodBtn.Size = new System.Drawing.Size(132, 27);
            this.foodBtn.Text = "Manage Food";
            this.foodBtn.Click += new System.EventHandler(this.foodBtn_Click);
            // 
            // expenseBtn
            // 
            this.expenseBtn.Name = "expenseBtn";
            this.expenseBtn.Size = new System.Drawing.Size(132, 27);
            this.expenseBtn.Text = "Show Expenses";
            this.expenseBtn.Click += new System.EventHandler(this.expenseBtn_Click);
            // 
            // reportBtn
            // 
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(132, 27);
            this.reportBtn.Text = "Sales Report";
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // invoiceBtn
            // 
            this.invoiceBtn.Name = "invoiceBtn";
            this.invoiceBtn.Size = new System.Drawing.Size(132, 27);
            this.invoiceBtn.Text = "Print Invoice";
            this.invoiceBtn.Click += new System.EventHandler(this.invoiceBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(132, 27);
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Restaurant_Management_Syatem.Properties.Resources._79f202b2a76562b279f5002533b1ef4e;
            this.pictureBox1.Location = new System.Drawing.Point(145, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(454, 352);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // emailBtn
            // 
            this.emailBtn.Name = "emailBtn";
            this.emailBtn.Size = new System.Drawing.Size(132, 27);
            this.emailBtn.Text = "Email";
            this.emailBtn.Click += new System.EventHandler(this.emailBtn_Click);
            // 
            // Manager_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(599, 352);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Manager_Panel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager_Panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Manager_Panel_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem foodBtn;
        private System.Windows.Forms.ToolStripMenuItem employeeBtn;
        private System.Windows.Forms.ToolStripMenuItem expenseBtn;
        private System.Windows.Forms.ToolStripMenuItem reportBtn;
        private System.Windows.Forms.ToolStripMenuItem invoiceBtn;
        private System.Windows.Forms.ToolStripMenuItem logoutBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem emailBtn;
    }
}