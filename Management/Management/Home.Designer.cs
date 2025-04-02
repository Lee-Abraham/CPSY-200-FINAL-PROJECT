namespace Management
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttCustomer = new System.Windows.Forms.Button();
            this.buttEquipment = new System.Windows.Forms.Button();
            this.buttRent = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // buttCustomer
            // 
            this.buttCustomer.BackColor = System.Drawing.Color.White;
            this.buttCustomer.Location = new System.Drawing.Point(307, 140);
            this.buttCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.buttCustomer.Name = "buttCustomer";
            this.buttCustomer.Size = new System.Drawing.Size(136, 30);
            this.buttCustomer.TabIndex = 0;
            this.buttCustomer.Text = "Customer";
            this.buttCustomer.UseVisualStyleBackColor = false;
            this.buttCustomer.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttEquipment
            // 
            this.buttEquipment.Location = new System.Drawing.Point(307, 294);
            this.buttEquipment.Margin = new System.Windows.Forms.Padding(2);
            this.buttEquipment.Name = "buttEquipment";
            this.buttEquipment.Size = new System.Drawing.Size(136, 30);
            this.buttEquipment.TabIndex = 1;
            this.buttEquipment.Text = "Equipment";
            this.buttEquipment.UseVisualStyleBackColor = true;
            this.buttEquipment.Click += new System.EventHandler(this.buttEquipment_Click);
            // 
            // buttRent
            // 
            this.buttRent.Location = new System.Drawing.Point(307, 444);
            this.buttRent.Margin = new System.Windows.Forms.Padding(2);
            this.buttRent.Name = "buttRent";
            this.buttRent.Size = new System.Drawing.Size(136, 30);
            this.buttRent.TabIndex = 2;
            this.buttRent.Text = "Rent";
            this.buttRent.UseVisualStyleBackColor = true;
            this.buttRent.Click += new System.EventHandler(this.buttRent_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(305, 25);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Inventory Management System";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(144, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(144, 284);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(144, 434);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 50);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(600, 50);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 612);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttRent);
            this.Controls.Add(this.buttEquipment);
            this.Controls.Add(this.buttCustomer);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttCustomer;
        private System.Windows.Forms.Button buttEquipment;
        private System.Windows.Forms.Button buttRent;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

