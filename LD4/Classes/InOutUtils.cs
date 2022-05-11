using System;
using System.Collections.Generic;
using System.IO;

namespace LD4
{
    public static class InOutUtils
    {
        /// <summary>
        /// Reads data from .txt files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns>List of sites</returns>
        /// <exception cref="Exception"></exception>
        public static List<Site> ReadSites(string[] fileNames)
        {
            List<Site> sites = new List<Site>();

            foreach(string file in fileNames)
            {
                string[] allDirs = file.Split('\\');
                if (File.ReadAllText(file).Length == 0)
                {
                    throw new Exception(String.Format("{0} failas yra tuščias.", allDirs[allDirs.Length - 1]));
                }
                using(StreamReader reader = new StreamReader(file, System.Text.Encoding.UTF8))
                {
                    string line = "";
                    string city = reader.ReadLine();
                    string manager = reader.ReadLine();
                    
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        
                        if(parts.Length != 7 && parts.Length != 5)
                        {
                            
                            throw new Exception(String.Format("Negalimas duomenų laikų skaičius {0} faile, eilutė: \n {1}",allDirs[allDirs.Length - 1], line));
                        }
                        else if(parts.Length == 7)
                        {
                          
                            sites.Add(new Museum(city,
                                manager,
                                parts[0],
                                parts[1],
                                DateTime.Parse(parts[2]),
                                parts[3],
                                parts[4],
                                bool.Parse(parts[5]),
                                decimal.Parse(parts[6])));
                               
                        }
                        else
                        {
                            sites.Add(new Statue(city,
                                manager,
                                parts[0],
                                parts[1],
                                DateTime.Parse(parts[2]),
                                parts[3],
                                parts[4]));
                        }
                    }
                }
            }
            return sites;
        }
        /// <summary>
        /// Prints sites to .csv file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        public static void PrintToCsvFile(List<Site> data, string fileName, string header)
        {
            using(StreamWriter writer = new StreamWriter(fileName, false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(header);
                foreach(Site entry in data)
                {
                    writer.WriteLine(entry.GetCsvLine());
                }
            }
        }
        /// <summary>
        /// Prints data to .txt file in tables
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="header"></param>
        /// <param name="format"></param>
        public static void PrintToTxtFile(List<Site> data, string fileName, string header, string format)
        {
            
            using (StreamWriter writer = new StreamWriter(fileName, true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(header);
                writer.WriteLine(format);
                foreach (Site entry in data)
                {
                    writer.WriteLine(entry.ToString());
                }
                writer.WriteLine();
            }
        }
       
    }
}