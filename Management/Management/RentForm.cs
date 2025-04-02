using System;
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
    }
}
