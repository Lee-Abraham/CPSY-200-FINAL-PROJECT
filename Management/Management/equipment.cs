using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management
{
    public class equipment
    {
        public int eqId {  get; set; }
        public int cateId { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public float dailRate { get; set; }

        public equipment()
        {
            this.eqId = 0;
            this.cateId = 0;
            this.name = string.Empty;
            this.desc = string.Empty;
            this.dailRate = 0;
        }

        public equipment(int eqId, int cateId, string name, string desc, float dailRate)
        {
            this.eqId = eqId;
            this.cateId = cateId;
            this.name = name;
            this.desc = desc;
            this.dailRate = dailRate;
        }

        //---------------------------------------------------------
        //To string for file

        public override string ToString()
        {

            return $"{eqId}, {cateId}, {name}, {desc}, {dailRate}";
        }

        //---------------------------------------------------------
        //Get all equipment.

        public static List<equipment> equipmentList(string filepath)
        {
            List<equipment> equipment = new List<equipment>();

            using (StreamReader read = new StreamReader(filepath))
            {
                //Do this operations
                try
                {

                    while (!read.EndOfStream)
                    {
                        string line = read.ReadLine();

                        string[] parts = line.Split(',');
                        
                        int id = int.Parse(parts[0]);
                        int catid = int.Parse(parts[1]);
                        string name = parts[2];
                        string desc = parts[3];
                        float dailRate = float.Parse(parts[4]); 

                        equipment.Add(new equipment(id, catid, name, desc, dailRate));
                    }
                    
                }

                //IF operations return an error
                catch( Exception ex) 
                {
                    MessageBox.Show($"An unexpected error: {ex.Message}");
                }
            }

            return equipment;
        }

        //---------------------------------------------------------
        //Get equipment using id.

        public static equipment equipmentUsingID(int ID, string filepath)
        {
            equipment equipment = new equipment();

            using (StreamReader read = new StreamReader(filepath))
            {
                //Do this operations
                try
                {
                    //Itirates over all the equipments.
                    while (!read.EndOfStream)
                    {
                        string line = read.ReadLine();

                        string[] parts = line.Split(',');

                        int id = int.Parse(parts[0]);
                        int catid = int.Parse(parts[1]);
                        string name = parts[2];
                        string desc = parts[3];
                        float dailRate = float.Parse(parts[4]);

                        //Check if id is same with ID.
                        if (ID == id)
                        {
                            return equipment = new equipment(id, catid, name, desc, dailRate);
                        }
                        
                    }

                }

                //IF operations return an error
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error: {ex.Message}");
                }
            }

            return equipment;
        }

        //---------------------------------------------------------
        //Append equipment

        public void appendEq(equipment eq, string filepath)
        {
            try 
            {
                using (StreamWriter write = new StreamWriter(filepath, true))
                {
                    write.WriteLine(eq.ToString());
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }


        //---------------------------------------------------------
        //Remove equipment

        public void remEq(string filepath, int idTorem)
        {
            try 
            { 
                //Get all lines in the data
                var lines = File.ReadLines(filepath).ToList();

                //Change the data on file
                lines = lines.Where(line =>
                {
                    string[] parts = line.Split(',');

                    if(parts.Length == 5 && int.TryParse(parts[0], out int id))
                    {
                        return id != idTorem;
                    }
                    return true;

                }).ToList();

                //Write new data to file
                File.WriteAllLines(filepath, lines);
            }

            catch(Exception ex) 
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }

        //---------------------------------------------------------
        //Generate unique ID.

        public static int GetUnID(List<equipment> equipmentList, int catID)
        {
            //Get the category number
            int currID = catID * 100;

            //appends 1 to be 101
            int nextID = currID + 1;

            //Get all existing equipment ID
            HashSet<int> ids = new HashSet<int>(equipmentList.Where( e => e.cateId == catID).Select(e => e.eqId) );

            while( ids.Contains(nextID) )
            {
                nextID++;
            }

            return nextID;
        }

        //---------------------------------------------------------
        //Get all equipment ID.

        public List<int> GetEqID(List<equipment> equip)
        {
            return new HashSet<int>(equip.Select(c => c.eqId)).ToList();
        }


    }
}