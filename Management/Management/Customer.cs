using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Management
{
    public class Customer
    {
        public int currid = 1000;
        //Customer id
        public int Id { get; set; }
        //Customer last name
        public string Lname { get; set; }
        //Customer first name
        public string Fname { get; set; }
        //Customer contact info
        public string Phone {  get; set; }
        //Customer email address.
        public string Email { get; set; }

        public Customer() 
        {
            this.Id = 0;
            this.Lname = string.Empty;
            this.Fname = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
        }

        public Customer(int id, string lname, string fname, string phone, string email)
        {
            Id = id;
            Lname = lname;
            Fname = fname;
            Phone = phone;
            Email = email;
        }

        //Format phone number
        public string FormatPhone(string phone)
        {
            string digits = new string(phone.Where(char.IsDigit).ToArray());

            return $"{digits.Substring(0, 3)}-{digits.Substring(3,3)}-{digits.Substring(6, 4)}";
        }

        //--------------------------------------------------------------------
        //Takes the input and makes it to string
        public override string ToString()
        {
            return $"{Id}, {Lname}, {Fname}, {Phone}, {Email}";
        }


        //--------------------------------------------------------------------
        //Check if Id is unique 
        public static int IdUnique(List<Customer> customers)
        {
            int startId = 1000;

            HashSet<int> existID = new HashSet<int>(customers.Select(c => c.Id));

            do 
            {
                startId += 1;
            }
            while (startId < 99999 && existID.Contains(startId));
            
            return startId;

        }


        //--------------------------------------------------------------------
        //Get customer, list of all customer.
        public static List<Customer> GetCustomer(string filePath)
        {
            List<Customer> customer = new List<Customer>();

            //Check if the file exist or not
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        //Change data type using parse
                        string[] parts = line.Split(',');

                        if (parts.Length == 5) //Validate data
                        {
                            int id = int.Parse(parts[0]);
                            string lname = parts[1];
                            string fname = parts[2];
                            string phone = parts[3];
                            string email = parts[4];

                            customer.Add(new Customer(id, lname, fname, phone, email));
                        }
                    }
                }
            }

            return customer;
        }

        //--------------------------------------------------------------------
        //Append the data to existing file.
        public void AppendData(string filepath, Customer customers)
        {
            using (StreamWriter w = File.AppendText(filepath))
            {

                w.WriteLine(customers.ToString());

            }
        }

        //--------------------------------------------------------------------
        //Edit data
        public static void OvverData(string filepath, List<Customer> customers)
        {
            using (StreamWriter w = new StreamWriter(filepath, false))
            {
                foreach (Customer custom in customers)
                {
                    w.WriteLine(custom.ToString());
                }
            }
        }

        //--------------------------------------------------------------------
        //Get customer id
        public List<int> getCusID(List<Customer> customers)
        {
            return new HashSet<int>(customers.Select(c => c.Id)).ToList();
        }

    }


}