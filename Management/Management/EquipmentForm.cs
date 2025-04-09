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
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"equipment\equipment.txt");

            //Load customer data
            List<equipment> Custlist = equipment.equipmentList(filepath);

            //Bind customer to data grid view
            dataGridView1.DataSource = Custlist;
            CustomizeHeaders();
            panel2.Hide();
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
                    comboBox1.Items.Add(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //-----------------------------------------------------------------
            //Populate category id.
            //FIlePath
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Category\category.txt");

            try
            {
                //Get list of all equipment.
                List<category> cat = category.getCat(filePath);

                //Remove all equipment ID. // Updates it
                comboBox2.Items.Clear();

                foreach (int id in new category().GetCatID(cat))
                {
                    comboBox2.Items.Add(id);
                    comboBox3.Items.Add(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //Add equipment
        private void button1_Click(object sender, EventArgs e)
        {
            //String path for Category
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"equipment\equipment.txt");

            int catid = int.Parse(comboBox2.Text);
            string name = textBox2.Text.Trim();
            float dailRate = float.Parse(textBox3.Text.Trim());
            string desc = textBox4.Text.Trim();

            if (catid == 0 || string.IsNullOrEmpty(name) || dailRate == 0 || string.IsNullOrEmpty(desc))
            {
                MessageBox.Show($"All fields must be filled");
                return;
            }

            //Create equipment
            equipment eq = new equipment();


            //Generate Equipment id
            int EqID = equipment.GetUnID(equipment.equipmentList(filepath), catid);

            eq.appendEq(new equipment(EqID, catid, name, desc, dailRate), filepath);

            comboBox2.Text = string.Empty;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            MessageBox.Show("New Equipment added");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ID
            int selectedID = int.Parse(comboBox1.Text.ToString());

            //FIlePath
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"equipment\equipment.txt");

            //Get equipment data
            List<equipment> dataeq = equipment.equipmentList(filePath);

            equipment selectedEq = dataeq.Find(c => c.eqId == selectedID);

            comboBox3.Text = selectedEq.cateId.ToString().Trim();
            textBox6.Text = selectedEq.name.Trim();
            textBox7.Text = selectedEq.dailRate.ToString().Trim();
            textBox8.Text = selectedEq.desc.Trim();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox3.Text.Trim()))
            {
                comboBox3.DroppedDown = false;
                return;
            }
            else
            {
                comboBox3.DroppedDown = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Define file path.
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"equipment\equipment");

            //Valid id
            if (!int.TryParse(comboBox1.Text.Trim(), out int equipmentId))
            {
                MessageBox.Show("Please select a valid Equipment ID");
                return;
            }

            //Show confirmation promt.
            var confirmResult = MessageBox.Show($"Are you sure you want to remove this equipment?", "Confirm removal", MessageBoxButtons.YesNo );

            //Cancells if no
            if (confirmResult == DialogResult.No)
            {
                return;
            }

            //Do if yes
            try
            {
                equipment eq = new equipment();

                eq.remEq(filepath, equipmentId);

                MessageBox.Show($"Equipment have been remove!!!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void CustomizeHeaders()
        {
            // Set custom column headers
            dataGridView1.Columns["eqId"].HeaderText = "Equipment ID";
            dataGridView1.Columns["cateId"].HeaderText = "Category ID";
            dataGridView1.Columns["name"].HeaderText = "Equipment Name";
            dataGridView1.Columns["desc"].HeaderText = "Description";
            dataGridView1.Columns["dailRate"].HeaderText = "Daily Rental Rate";
        }
    }
}
