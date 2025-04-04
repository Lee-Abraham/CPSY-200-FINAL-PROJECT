using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management
{
    public class Customer
    {
        int currid = 1000;
        //Customer id
        int Id { get; set; }
        //Customer last name
        string Lname { get; set; }
        //Customer first name
        string Fname { get; set; }
        //Customer contact info
        string Phone {  get; set; }
        //Customer email address.
        string Email { get; set; }

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

        //Takes the input and makes it to string
        public override string ToString()
        {
            return $"{Id}, {Lname}, {Fname}, {Phone}, {Email}";
        }

        //Check if Id us unique 
        public static int IdUnique(List<Customer> customers)
        {
            int startId = 1000;
            int currID;

            HashSet<int> existID = new HashSet<int>(customers.Select(c => c.Id));
                //Targets the IDs of the customer.
            //foreach (var customer in customers)
            //{
            //    existID.Add(customer.Id);
            //}

            do 
            {
                startId += 1;
            }
            while (startId < 9999 && existID.Contains(startId));
            
            return startId;

        }

        //Append the data to existing file.
        public void AppendData(string filepath, List<Customer> customers)
        {
            using (StreamWriter w = File.AppendText(filepath))
            {
                foreach (var customer in customers)
                {
                    w.WriteLine(customer.ToString());
                }
            }
        }

    }

    public class cusData
    {

        public List<Customer> GetCustomer(string filePath)
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
    }
}
