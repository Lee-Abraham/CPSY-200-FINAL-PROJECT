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

namespace Management
{
    public partial class EquipmentForm : Form
    {
        public EquipmentForm()
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

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            //String path for Category
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Category\category.txt");

        }
    }
}
