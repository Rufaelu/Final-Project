using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project_store_management
{
    public partial class Admin_Page : UserControl
    {
        byte[] imageemp;
        byte[] imageprod;
        public Admin_Page()
        {  

            InitializeComponent();
            timer1.Start();
        }

        private void importbtn_Click(object sender, EventArgs e)
        {
          //  byte[] image = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Read the selected image file into byte array
                 imageprod = File.ReadAllBytes(openFileDialog.FileName);

                // Insert the image into the database
                MessageBox.Show("Image uploaded successfully!");
             // DisplayImage(imageprod);
            
            }
            
        }
        private void InsertImageIntoDatabase(byte[] imageData,string name)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=RUFAEL;Initial Catalog=Pictest;Integrated Security=True"))
            {
                connection.Open();

                // Use parameterized query to prevent SQL injection
                string query = "INSERT INTO Testing VALUES (@name,@ImageData)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@ImageData", imageData);
                    command.ExecuteNonQuery();
                }
            }
        }
        private void RetrieveImageFromDatabase(string name,object sender)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=RUFAEL;Initial Catalog=Pictest;Integrated Security=True"))
            {
                connection.Open();
               
                    string query = $"SELECT Top 1 pic FROM Testing where name='{name}'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (sender == searchproductbtn1searchproductbtn1)
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                imageemp = (byte[])reader["pic"];
                                DisplayImage(imageemp, searchproductbtn1searchproductbtn1);
                            }
                        }
                    }
                    //else if
                }
            }
        }

        private void DisplayImage(byte[] imageData, object sender)
        {
            // Convert byte array to image and display it in PictureBox
            using (MemoryStream stream = new MemoryStream(imageData))
            {if(sender==employeepicbox1)
                employeepicbox1.Image = Image.FromStream(stream);
            else if(sender==pictureBox2)
                    pictureBox2.Image = Image.FromStream(stream);
            }
            
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if(colorproduct1.Text ==""||nameproducttb1.Text=="" || quantityproducttb1.Text == "" || pricetb1.Text == ""||categoryproductcb1.SelectedText==null||sizeproductcb1.SelectedText==null||employeepicbox1.Image==null) {
                MessageBox.Show("Please Fill Every information", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InsertImageIntoDatabase(imageemp, nameproducttb1.Text);
              //  RetrieveImageFromDatabase(textBox10.Text);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Read the selected image file into byte array
                imageemp = File.ReadAllBytes(openFileDialog.FileName);

                // Insert the image into the database
                MessageBox.Show("Image uploaded successfully!");
                DisplayImage(imageemp,impempbtn);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fullnameemptb1.Text == "" || dobemptb1.Text == "" || salaryemp1.Text == ""  || roleempcb1.SelectedText == null || genderempcb1.SelectedText == null || employeepicbox1.Image == null)
            {
                MessageBox.Show("Please Fill Every information", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {//Must be changed
                MessageBox.Show("Success inserting");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerlbl.Text = DateTime.Now.ToString();
            timercust.Text = DateTime.Now.ToString();
            timeremp.Text = DateTime.Now.ToString();
            timersales.Text = DateTime.Now.ToString();
            timersupplier.Text = DateTime.Now.ToString();

        }

        private void Logoutbtn_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Form1.close();
            /*Form parentform = this.ParentForm;
            if (parentform is Form1)
            {
                // You can hide or close the current form (user control) and show Form1
                parentform.Show();
                this.Hide(); // or this.Close() depending on your requirements
            }*/


        }
    }
}
