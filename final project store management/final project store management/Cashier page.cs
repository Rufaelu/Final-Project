using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project_store_management
{
    public partial class Cashier_page : UserControl
    {
        public Cashier_page()
        {
            
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timercharierlbl.Text = DateTime.Now.ToString();
        }

        private void logoutbtncash_Click(object sender, EventArgs e)
        {
            Form1.close();
        }
    }
}
