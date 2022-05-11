using System;

namespace LD4
{
    /// <summary>
    /// Class for Statue data
    /// </summary>
    public class Statue : Site, IComparable<Statue>,  IEquatable<Statue>
    {
        public string Author { get; set; }
        public string StatueName { get; set; }
        /// <summary>
        /// Constructor for Statue object
        /// </summary>
        /// <param name="city"></param>
        /// <param name="manager"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="date"></param>
        /// <param name="author"></param>
        /// <param name="statueName"></param>
        public Statue(string city, string manager, string name, string address, DateTime date, string author, string statueName) : base(city, manager, name, address, date)
        {
            Author = author;
            StatueName = statueName;
        }
        public override string GetCsvLine()
        {
            return String.Join(",", Name, Address, Date.ToString("yyyy-MM-dd"), Author, StatueName);
        }
        /// <summary>
        /// Overridden ToString() method to get all data fields in table format
        /// </summary>
        /// <returns>String of all data fields</returns>
        public override string ToString()
        {
            return String.Format("| {0, -10} | {1, -20} | {2, -15} | {3,-20} | {4, 10} | {5,-10} | {6, -10} |",
                City, Manager, Name, Address, Date.ToString("yyyy-MM-dd"), Author, StatueName);
        }
        public int CompareTo(Statue other)
        {
            if(other == null) return 1;
            return Author.CompareTo(other.Author);
        }

        public bool Equals(Statue other)
        {
            return Name == other.Name && Address == other.Address && Date == other.Date && Author == other.Author && StatueName == other.StatueName;
        }
    }
}