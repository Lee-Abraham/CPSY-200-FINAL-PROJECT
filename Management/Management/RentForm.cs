using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Management
{
    public partial class RentForm : Form
    {
        public RentForm()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            //Create constructor for home form
            Home form = new Home();

            //Show the home form
            form.Show();

            //Close this form
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //Customer id
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedID = int.Parse(comboBox1.Text.ToString());

            //FIlePath
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Customer\customers.txt");

            //Get customer data
            List<Customer> dataCustomers = Customer.GetCustomer(filePath);


            Customer selectedCustomer = dataCustomers.Find(c => c.Id == selectedID);

            textBox2.Text = selectedCustomer.Lname;
            textBox1.Text = selectedCustomer.Fname;

        }

        private void RentForm_Load(object sender, EventArgs e)
        {
            //Add customer ID

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



            //-----------------------------------------------------------------
            //String path for Eq
            string filepatheq = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"equipment\equipment.txt");

            try
            {
                //Get list of all equipment.
                List<equipment> cat = equipment.equipmentList(filepatheq);

                //Remove all equipment ID. // Updates it
                comboBox2.Items.Clear();

                foreach (int id in new equipment().GetEqID(cat))
                {
                    comboBox2.Items.Add(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ID
            int selectedID = int.Parse(comboBox2.Text.ToString());

            //FIlePath
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"equipment\equipment.txt");

            //Get equipment data
            List<equipment> dataeq = equipment.equipmentList(filePath);

            equipment selectedEq = dataeq.Find(c => c.eqId == selectedID);

            textBox3.Text = selectedEq.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Get date of start of rent
            DateTime starRent = dateTimePicker1.Value;

            //Get date of end of rent
            DateTime endRent = dateTimePicker2.Value;

            //Get equipment

                //Get equipment id.
            int eqID = int.Parse(comboBox2.Text.ToString());

                //File math for equipment.
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"equipment\equipment.txt");

                //Get list of equipment data.
            List<equipment> dataeq = equipment.equipmentList(filePath);

                //Get selected equipment.
            equipment selectedEq = dataeq.Find(c => c.eqId == eqID);


            //Get customer
                //Get customer id.
            int cusID = int.Parse(comboBox1.Text.ToString());

                //File path for customer.
            string filePathCus = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Customer\customers.txt");

                //Get list of customer data.
            List<Customer> dataCustomers = Customer.GetCustomer(filePathCus);

                //Get selected Customer.
            Customer selectedCustomer = dataCustomers.Find(c => c.Id == cusID);

            //Actuall function that operates the data.

            Renting.rentEq(selectedEq, selectedCustomer, starRent, endRent);
            
        }
    }
}
