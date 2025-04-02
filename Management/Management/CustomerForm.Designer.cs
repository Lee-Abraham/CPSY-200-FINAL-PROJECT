namespace Management
{
    partial class CustomerForm
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
            this.Home = new System.Windows.Forms.Button();
            this.addCustomer = new System.Windows.Forms.Button();
            this.editCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Home
            // 
            this.Home.Location = new System.Drawing.Point(12, 22);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(75, 23);
            this.Home.TabIndex = 0;
            this.Home.Text = "Back";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.button1_Click);
            // 
            // addCustomer
            // 
            this.addCustomer.Location = new System.Drawing.Point(210, 357);
            this.addCustomer.Name = "addCustomer";
            this.addCustomer.Size = new System.Drawing.Size(105, 42);
            this.addCustomer.TabIndex = 1;
            this.addCustomer.Text = "Add Customer";
            this.addCustomer.UseVisualStyleBackColor = true;
            // 
            // editCustomer
            // 
            this.editCustomer.Location = new System.Drawing.Point(454, 357);
            this.editCustomer.Name = "editCustomer";
            this.editCustomer.Size = new System.Drawing.Size(105, 42);
            this.editCustomer.TabIndex = 2;
            this.editCustomer.Text = "Edit customer data";
            this.editCustomer.UseVisualStyleBackColor = true;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.editCustomer);
            this.Controls.Add(this.addCustomer);
            this.Controls.Add(this.Home);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Button addCustomer;
        private System.Windows.Forms.Button editCustomer;
    }
}