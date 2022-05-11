using System;

namespace LD4
{
    /// <summary>
    /// Class for Museum data
    /// </summary>
    public class Museum : Site, IComparable<Museum>, IEquatable<Museum>
    {
        public string Type { get; set; }
        public bool HasGuide { get; set; }
        public decimal TicketPrice { get; set; }
        public string WorkDays { get; set; }

        /// <summary>
        /// Constructor for Museum object
        /// </summary>
        /// <param name="city"></param>
        /// <param name="manager"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="date"></param>
        /// <param name="type"></param>
        /// <param name="workDays"></param>
        /// <param name="hasGuide"></param>
        /// <param name="ticketPrice"></param>
        public Museum(string city, string manager, string name, string address, DateTime date, string type, string workDays, bool hasGuide, decimal ticketPrice) : base(city, manager, name, address, date)
        {
            Type = type;
            HasGuide = hasGuide;
            TicketPrice = ticketPrice;
            WorkDays = workDays;
        }
       
        public override string GetCsvLine()
        {
            return String.Join(",", Name, Address, Date.ToString("yyyy-MM-dd"), Type, HasGuide, WorkDays, TicketPrice);
        }
        /// <summary>
        /// Overridden ToString() method to get all data fields in table format
        /// </summary>
        /// <returns>String of all data fields</returns>
        public override string ToString()
        {
            return String.Format("| {0, -10} | {1, -20} | {2, -15} | {3, -20} | {4,10} | {5,-10} | {6,-10} | {7,-5} | {8, 5} |",
                City, Manager, Name, Address, Date.ToString("yyyy-MM-dd"), Type, WorkDays, HasGuide, TicketPrice);
        }
       
        public int CompareTo(Museum other)
        {
            if (other == null) return 1;
            return TicketPrice.CompareTo(other.TicketPrice);
        }

        public bool Equals(Museum other)
        {
            return Name == other.Name && Address == other.Address && Date == other.Date && Type == other.Type && WorkDays == other.WorkDays
                && HasGuide == other.HasGuide && TicketPrice == other.TicketPrice;
        }
    }
}