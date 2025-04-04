using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management
{
    public class Customer
    {
        private static int currID = 1000;
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

        public Customer(string lname, string fname, string phone, string email)
        {
            this.Id = ++currID;
            Lname = lname;
            Fname = fname;
            Phone = phone;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Id}, {Lname}, {Fname}, {Phone}, {Email}";
        }

        public void SaveCustomData(string filepath, List<Customer> customer)
        {
            using  (StreamWriter w =  new StreamWriter(filepath))
            {
                foreach (Customer customerItem in customer)
                {
                    w.WriteLine(customerItem.ToString());
                }
            }
        }
    }
}
