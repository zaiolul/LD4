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
        public static List<Tuple<string, List<Site>>> ReadSites(string[] fileNames)
        {
            List<Tuple<string, List<Site>>> data = new List<Tuple<string, List<Site>>>();

            if(fileNames.Length == 0)
            {
                throw new Exception("Nerasta duomenų failų.");
            }
            
            foreach(string file in fileNames)
            {
                List<Site> sites = new List<Site>();
                string[] allDirs = file.Split('\\');
                string fileName = allDirs[allDirs.Length - 1];
                if (File.ReadAllText(file).Length == 0)
                {
                    throw new Exception(String.Format("{0} failas yra tuščias.", fileName));
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
                            
                            throw new Exception(String.Format("Negalimas duomenų laikų skaičius {0} faile, eilutė: \n {1}", fileName, line));
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
                data.Add(new Tuple<string,List<Site>>(fileName, sites));
            }
            return data;
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
        /// Prints data from each data file to a .txt file in table format
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="header"></param>
        /// <param name="format"></param>
        public static void PrintToTxtFile(List<Tuple<string, List<Site>>> data, string fileName, string header, string format)
        {
            foreach(var entry in data)
            {
                PrintToTxtFile(entry.Item2, fileName, entry.Item1 + " " + header, format);
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