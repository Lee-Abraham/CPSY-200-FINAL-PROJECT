using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //Create constructor for home form
            Home form = new Home();

            //Show the home form
            form.Show();

            //Close this form
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
                Color.Black, 2, ButtonBorderStyle.Solid, // Top border
                Color.Black, 2, ButtonBorderStyle.Solid, // Left border
                Color.Black, 2, ButtonBorderStyle.Solid, // Bottom border
                Color.Black, 2, ButtonBorderStyle.Solid  // Right border
            );
        }

        private void userName_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        List<Customer> Savelist = new List<Customer>();

        private void addCustomer_Click(object sender, EventArgs e)
        {
            string lname = textBox1.Text;
            string fname = textBox2.Text;
            string phone = textBox3.Text;
            string email = textBox4.Text;

            string phoneFix = phone.Replace("-", "");

            //Validation of fields
            if (string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(fname) || string.IsNullOrEmpty (phone) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("One of the fields is empty.");
                return;
            }

            //Validate phone and email
            if (!email.Contains("@") || email.Contains(" "))
            {
                MessageBox.Show("Enter valid email. Ex. email@gmail.com");
                return;
            }
            if (phoneFix.Length != 10 || !long.TryParse(phoneFix, out _))
            {
                MessageBox.Show("Enter valid phone number. Ex. 123-345-7891");
                return;
            }

            //FIlePath
            string filePath = "Customer.customers.txt";

            //Retrive customer datas
            cusData cusData = new cusData();


            //Get id
            int uniqueID = Customer.IdUnique(cusData.GetCustomer(filePath));

            //Creates a constructore with the data on the box.
            Customer customer = new Customer(uniqueID, lname, fname, phoneFix, email);

            //Saves the new customer to SavedList.
            Savelist.Add(customer);

            //Save user data to file
            customer.AppendData(filePath, Savelist);

            //Gives user a notification of data being saved.
            MessageBox.Show("Data saved");

            //Remove the text on the textbox
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

    }
}
