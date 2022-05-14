using System;
using System.Collections.Generic;

namespace LD4
{
    public static class TaskUtils
    {
        /// <summary>
        /// Merges data from each file into one list
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Merged file data list</returns>
        public static List<Site> GetMergedSites(List<Tuple<string, List<Site>>> data)
        {
            List<Site> sites = new List<Site>();
            foreach(var entry in data)
            {
                foreach(Site site in entry.Item2)
                {
                    sites.Add(site);
                }
            }
            return sites;
        }
        /// <summary>
        /// Gets the number of sites which have a guide
        /// </summary>
        /// <param name="sites"></param>
        /// <returns>Number of sites with guides</returns>
        public static int GetGuidesCount(List<Site> sites)
        {
            int count = 0;
            foreach(Site site in sites)
            {
                if(site is Museum && ((Museum)site).HasGuide)
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Checks list of sites for all sites available to visit on the weekend
        /// </summary>
        /// <param name="sites"></param>
        /// <returns>List of sites, visitable on the weekend</returns>
        public static List<Site> GetVisitableOnWeekend(List<Site> sites)
        {
            List<Site> filtered = new List<Site>();
            foreach(Site site in sites)
            {
                if(site is Museum)
                {
                    Museum museum = (Museum)site;
                    if (museum.WorkDays.Length < 7)
                    {
                        throw new Exception(String.Format("Netinkamas darbo dienų kiekis: {0}", museum.GetCsvLine()));
                    }
                    if(museum.WorkDays[5] == '1' || museum.WorkDays[6] == '1')
                    {
                        filtered.Add(museum);
                    }
                }
            }
            return filtered;
        }
        /// <summary>
        /// Finds all statues made by the same author
        /// </summary>
        /// <param name="sites"></param>
        /// <param name="author"></param>
        /// <returns>List of all statues by the same author</returns>
        public static List<Site> GetStatuesByAuthor(List<Site> sites, string author)
        {
            List<Site> filtered = new List<Site>();
            foreach(Site site in sites)
            {
                if(site is Statue && ((Statue)site).Author == author)
                {
                    filtered.Add((Statue)site);
                }
            }
            return filtered;
        }
        /// <summary>
        /// Finds all the newest sites (museums less than 2 years old, statues less than a year old)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sites"></param>
        /// <param name="years"></param>
        /// <returns>List of newest sites</returns>
        public static List<T> GetNewestSites<T>(List<Site> sites, int years) where T : class
        {
            List<T> filtered = new List<T>();

            foreach(Site site in sites)
            {
                if(site is T && (DateTime.Today - site.Date).Days / 365 < years)     
                {
                    filtered.Add(site as T);
                }
            }
            return filtered;
        }
       

    }
}