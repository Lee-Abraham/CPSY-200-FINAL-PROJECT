﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        //Button for the Customer
        private void button1_Click(object sender, EventArgs e)
        {
            //Construct the form.cs
            CustomerForm form = new CustomerForm();

            //Show or get the Customer form
            form.Show();

            //Hide the 
            this.Hide();

        }

        //Button for the equipment
        private void buttEquipment_Click(object sender, EventArgs e)
        {
            //Constructor
            EquipmentForm form = new EquipmentForm();

            //Show new form
            form.Show();

            //Hide old form
            this.Hide();
        }

        //Equipment for renting
        private void buttRent_Click(object sender, EventArgs e)
        {
            //Constructor
            RentForm form = new RentForm();

            //Show new form
            form.Show();

            //Hide old form
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
