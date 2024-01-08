using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project_store_management
{
    public partial class Form1 : Form
    {
        Admin_Page admin_Page;
        Cashier_page cashier_Page;
        static Form1 f;
       public static void close()
        {
            f.Controls.Clear();
            f.initial();
        }
        public Form1()
        {
            initial();
            
            
        }
        void initial()
        {
            admin_Page = new Admin_Page();
            cashier_Page = new Cashier_page();


            f = this;
            InitializeComponent();
        }

        private void showpasschb_CheckedChanged(object sender, EventArgs e)
        {
            if (showpasschb.Checked)
                passwordtb.PasswordChar = '\0';
            else
                passwordtb.PasswordChar = '*';
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            if (textBox1.Text == "me")
                this.Controls.Add(admin_Page);
            else
            {
                this.Controls.Add(cashier_Page);
            }
        }
    }
}
