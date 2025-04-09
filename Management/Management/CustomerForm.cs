using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            string filePath = @"Customer\customers.txt";

            //Load customer data
            List<Customer> Custlist = Customer.GetCustomer(filePath);

            //Bind customer to data grid view
            dataGridView1.DataSource = Custlist;

            //Organize data
            CustomizeCustomerHeaders();

            //Hide the data panel.
            panel3.Hide();
        }


        // -----------------------------------------------------------------
        //Go back to home
        private void button1_Click(object sender, EventArgs e)
        {
            //Create constructor for home form
            Home form = new Home();

            //Show the home form
            form.Show();

            //Close this form
            this.Close();
        }

        // -----------------------------------------------------------------
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

        // -----------------------------------------------------------------
        //Admin can select user id to get customer.

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedID = int.Parse(comboBox1.Text.ToString());


            //FIlePath
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Customer\customers.txt");

            //Get customer data
            List<Customer> dataCustomers = Customer.GetCustomer(filePath);


            Customer selectedCustomer = dataCustomers.Find(c => c.Id == selectedID);

            textBox5.Text = selectedCustomer.Lname;
            textBox6.Text = selectedCustomer.Fname;
            textBox7.Text = selectedCustomer.FormatPhone(selectedCustomer.Phone);
            textBox8.Text = selectedCustomer.Email;
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

        //--------------------------------------------------------------------
        //Adds customer to .txt
        private void addCustomer_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Trim();
            textBox2.Text = textBox2.Text.Trim();
            textBox3.Text = textBox3.Text.Trim();
            textBox4.Text = textBox4.Text.Trim();

            //Get the text on the box
            string lname = textBox1.Text;
            string fname = textBox2.Text;
            string phone = textBox3.Text;
            string email = textBox4.Text;

            //Set the phone.
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
            string filePath = @"Customer\customers.txt";

            //Get customer data
            List<Customer> dataCustomers = Customer.GetCustomer(filePath);

            //Get id
            int uniqueID = Customer.IdUnique(dataCustomers);

            //Creates a constructore with the data on the box.
            Customer customer = new Customer(uniqueID,lname,fname,phoneFix,email);

            //Save user data to file
            customer.AppendData(filePath, customer);

            CustomerForm_Load(sender, e);

            //Remove the text on the textbox
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            //Gives user a notification of data being saved.
            MessageBox.Show("Data saved");
        }

        //--------------------------------------------------------------------
        //Edit customer data
        private void editCustomer_Click(object sender, EventArgs e)
        {

            textBox5.Text = textBox5.Text.Trim();
            textBox6.Text = textBox6.Text.Trim();
            textBox7.Text = textBox7.Text.Trim();
            textBox8.Text = textBox8.Text.Trim();

            //Get the text on the box
            string lname = textBox5.Text;
            string fname = textBox6.Text;
            string phone = textBox7.Text;
            string email = textBox8.Text;

            //Set the phone.
            string phoneFix = phone.Replace("-", "");

            //Validation
            //Validation of fields
            if (string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Input all data to user.");
                return;
            }

            //FIlePath
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Customer\customers.txt");

            //Get customers
            List<Customer> customer = Customer.GetCustomer(filePath);

            int selectedID = int.Parse(comboBox1.Text.ToString());

            List<Customer> newData = new List<Customer>();

            //Bool to see if user data have been updated
            bool isUpdated = false;

            //Change customer data
            foreach (Customer custom in customer)
            {
                if (custom.Id == selectedID)
                {
                    custom.Lname = lname;
                    custom.Fname = fname;
                    custom.Phone = phoneFix;
                    custom.Email = email;
                    isUpdated = true;
                    break;
                }
            }

            //Update the customer data.
            if (isUpdated)
            {
                Customer.OvverData(filePath, customer);
                MessageBox.Show("Customer data edited");
            }

            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

            CustomerForm_Load(sender, e);
        }

        //--------------------------------------------------------------------

        //Sets users id on the dropdown table.
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            //FIlePath
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Customer\customers.txt");

            //Get customer data
            List<Customer> dataCustomers = Customer.GetCustomer(filePath);

            //Remove any items from comboBox
            comboBox1.Items.Clear();

            //Itirates over the customer id and add it to comboBox
            foreach (int id in new Customer().getCusID(dataCustomers))
            {
                comboBox1.Items.Add(id);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustomizeCustomerHeaders()
        {
            // Change column headers
            dataGridView1.Columns["Id"].HeaderText = "Customer ID";
            dataGridView1.Columns["Fname"].HeaderText = "First Name";
            dataGridView1.Columns["Lname"].HeaderText = "Last Name";
            dataGridView1.Columns["Phone"].HeaderText = "Phone Number";
            dataGridView1.Columns["Email"].HeaderText = "Email Address";
        }
    }
}
