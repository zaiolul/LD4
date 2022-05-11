using System;

namespace LD4
{
    /// <summary>
    /// Base class for Site objects
    /// </summary>
    public abstract class Site
    {
        public string City { get; set; }
        public string Manager { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Constructor for Site object
        /// </summary>
        /// <param name="city"></param>
        /// <param name="manager"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="date"></param>
        protected Site(string city, string manager, string name, string address, DateTime date)
        {
            City = city;
            Manager = manager;
            Name = name;
            Address = address;
            Date = date;
        }
        /// <summary>
        /// Method to return all data fields in .csv format
        /// </summary>
        /// <returns>String of all data fields</returns>
        public abstract string GetCsvLine();
        
    }
}