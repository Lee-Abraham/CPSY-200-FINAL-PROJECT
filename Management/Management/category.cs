using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management
{
    public class category
    {
        public int catId {  get; set; }
        public string catName {  get; set; }

        public category() 
        {
            this.catId = 0;
            this.catName = string.Empty;
        }

        public category(int Id, string Name)
        {
            catId = Id;
            catName = Name;
        }

        //-----------------------------------------------------------
        //Get the category id & name.
        public override string ToString()
        {
            return $"{catId}, {catName}";
        }

        //-----------------------------------------------------------
        //Append category

        public void appendCat(category category, string filepath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filepath, true))
                {
                    sw.WriteLine(category.ToString());
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"An error occured while accessing the file: {ex}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex}");
            }

        }

        //-----------------------------------------------------------
        //Get category. ALL
        public List<category> getCat(string filepath)
        {
            List<category> cat = new List<category>();
            
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            int id = int.Parse(parts[0]);
                            string name = parts[1];
                            cat.Add(new category(id, name));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex}");
            }

            return cat;
        }

        //-----------------------------------------------------------
        //Get category. Using ID

        public category getCatID(int id, string filepath)
        {
            category cat = new category();

            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] parts = line.Split(',');

                        if (parts.Length == 2)
                        {
                            int ID = int.Parse(parts[0]);
                            string name = parts[1];
                            return cat = new category(id, name);
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex}");
            }

            return null;
        }


    }
}
