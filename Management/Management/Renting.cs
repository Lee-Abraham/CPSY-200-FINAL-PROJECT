using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Management
{
    public class Renting
    {
        public int rentID {  get; set; }

        public DateTime date { get; set; }

        public int renCusID { get; set; }

        public int renEqID { get; set; }

        public DateTime rentingDate { get; set; }

        public DateTime returnDate { get; set; }

        public float toCost {  get; set; }

        //Constructor when there is no data given
        public Renting() { }

        //Constructor when there is data given.
        public Renting(int rentID, DateTime date, int renCusID, int renEqID, DateTime rentingDate, DateTime returnDate, float cost)
        {
            this.rentID = rentID;
            this.date = date;
            this.renCusID = renCusID;
            this.renEqID = renEqID;
            this.rentingDate = rentingDate;
            this.returnDate = returnDate;
            this.toCost = cost;
        }


        //-----------------------------------------------------------------------
        //To string
        public override string ToString()
        {
            return $"{rentID}, {date:MM/dd/yyyy}, {renCusID}, {renEqID}, {rentingDate:MM/dd/yyyy}, {returnDate:MM/dd/yyyy}";
        }

        //-----------------------------------------------------------------------
        //Append data to existing file
        public static void appendRent(string filepath, Renting rent)
        {
            //Try method used incase there is an error.
            try 
            { 

                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    writer.WriteLine(rent.ToString());
                }

                MessageBox.Show("Renting have been stored");

            }

            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }

        //-----------------------------------------------------------------------
        //Generate Unique ID

        public static int GetUnID(string filepath)
        {
            try
            {
                //Get all lines from file
                var lines = File.ReadAllLines(filepath);

                //Get last ID, set 999 if no ID is found.
                int lastID = lines.Select(l => int.Parse(l.Split(',')[0])).DefaultIfEmpty(999).Max();

                //Return ID
                return Math.Max(1000, lastID + 1);
            }
            catch
            {
                return 1000;
            }
        }



        //-----------------------------------------------------------------------
        //To string   //Renting equipment
        public static void rentEq(equipment eq, Customer customer, DateTime rentDate, DateTime returDate)
        {
            //Validate user date
            if ( returDate <= rentDate)
            {
                MessageBox.Show("Return date must be after rental date.");
                return;
            }

            //Get number of days rented.
                //Subtract return date from rent date
            TimeSpan rentalDu = returDate - rentDate;
                //Get int type of date.
            int rentalDate = rentalDu.Days;

            //Get the total cost of rental
            float totalCost = rentalDate * eq.dailRate;

            //Generate current date for storage.
            DateTime currDate = DateTime.Now;

            //Display data to user
            MessageBox.Show($"Customer: {customer.Fname} {customer.Lname}\nEquipment: {eq.name}\nRental Start: {rentDate:MM/dd/yyyy}\nReturn Date: {returDate:MM/dd/yyyy}\nTransaction Date: {currDate:MM/dd/yyyy}\nTotal Cost: ${totalCost}");

            //Save data to file
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"rent\renting.txt");

            Renting ren = new Renting(GetUnID(filepath), currDate, customer.Id, eq.eqId, rentDate, returDate, totalCost);

            Renting.appendRent(filepath, ren);
        }


    }
}
