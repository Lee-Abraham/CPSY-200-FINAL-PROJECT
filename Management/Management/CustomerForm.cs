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
    }
}
