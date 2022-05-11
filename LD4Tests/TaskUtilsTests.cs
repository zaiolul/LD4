using Xunit;
using LD4;
using System.Collections.Generic;
using System;

namespace LD4Tests
{
    public class TaskUtilsTests
    {
        [Fact]
        public void GetGuidesCount_Get_Zero_List_Only_Statues()
        {
            List<Site> sites = new List<Site>();
            sites.Add(new Statue("a", "", "1", "", new DateTime(), "", ""));
            sites.Add(new Statue("b", "", "2", "", new DateTime(), "", ""));
            sites.Add(new Statue("c", "", "3", "", new DateTime(), "", ""));

            int count = TaskUtils.GetGuidesCount(sites);
            Assert.Equal(0, count);
        }
        [Fact]
        public void GetGuidesCount_Get_One_Single_Museum_With_Guide()
        {
            List<Site> sites = new List<Site>();
            sites.Add(new Statue("a", "", "1", "", new DateTime(), "", ""));
            sites.Add(new Statue("b", "", "2", "", new DateTime(), "", ""));
            sites.Add(new Statue("c", "", "3", "", new DateTime(), "", ""));
            sites.Add(new Museum("d", "", "4", "", new DateTime(), "", "", true, 0.0m));
            sites.Add(new Museum("e", "", "5", "", new DateTime(), "", "", false, 0.0m));

            int count = TaskUtils.GetGuidesCount(sites);
            Assert.Equal(1, count);
        }
        [Fact]
        public void GetVisitableOnWeekend_Get_Empty_List_If_None_Visitable()
        {
            List<Site> sites = new List<Site>();
            
            sites.Add(new Museum("a", "", "1", "", new DateTime(), "", "1111100", true, 0.0m));
            sites.Add(new Museum("b", "", "2", "", new DateTime(), "", "0000000", false, 0.0m));
            sites.Add(new Museum("c", "", "3", "", new DateTime(), "", "0101000", false, 0.0m));

            List<Site> newSites = TaskUtils.GetVisitableOnWeekend(sites);
            Assert.Empty(newSites);
        }
    
        [Fact]
        public void GetStatuesByAuthor_Get_Correct_Statues()
        {
            List<Site> sites = new List<Site>();
            Museum a = new Museum("a", "", "1", "", new DateTime(), "", "1111111", true, 0.0m);
            Museum b = new Museum("b", "", "2", "", new DateTime(), "", "0000011", false, 0.0m);
            Museum c = new Museum("c", "", "3", "", new DateTime(), "", "0101000", false, 0.0m);
            sites.Add(a);
            sites.Add(b);
            sites.Add(c);

            List<Site> newSites = TaskUtils.GetVisitableOnWeekend(sites);
            Assert.Contains(a, newSites);
            Assert.Contains(b, newSites);
        }

        [Fact]
        public void GetVisitableOnWeekend_Get_Correct_Statues()
        {
            List<Site> sites = new List<Site>();
            Statue a = new Statue("a", "", "1", "", new DateTime(), "AAA", "");
            Statue b = new Statue("b", "", "2", "", new DateTime(), "BBB", "");
            Statue c = new Statue("c", "", "3", "", new DateTime(), "AAA", "");

            sites.Add(a);
            sites.Add(b);
            sites.Add(c);

            List<Site> newSites = TaskUtils.GetStatuesByAuthor(sites, "AAA");
            Assert.Contains(a, newSites);
            Assert.Contains(c, newSites);
        }
        [Fact]
        public void GetVisitableOnWeekend_All_Museums_Get_Empty_List()
        {
            List<Site> sites = new List<Site>();
            Museum a = new Museum("a", "", "1", "", new DateTime(), "", "1111111", true, 0.0m);
            Museum b = new Museum("b", "", "2", "", new DateTime(), "", "0000011", false, 0.0m);
            Museum c = new Museum("c", "", "3", "", new DateTime(), "", "0101000", false, 0.0m);

            sites.Add(a);
            sites.Add(b);
            sites.Add(c);

            List<Site> newSites = TaskUtils.GetStatuesByAuthor(sites, "AAA");
            Assert.Empty(newSites);
            
        }
        [Fact]
        public void GetNewestSites_Get_Correct_Museums()
        {
            List<Site> sites = new List<Site>();
            
            Museum a = new Museum("a", "", "1", "", new DateTime(2021,7,7), "", "0000011", false, 0.0m);
            Museum b = new Museum("b", "", "2", "", new DateTime(1999,9,9), "", "0101000", false, 0.0m);
            Museum c = new Museum("c", "", "3", "", new DateTime(2022,1,1), "", "0101000", false, 0.0m);

            sites.Add(a);
            sites.Add(b);
            sites.Add(c);

            List<Museum> newSites = TaskUtils.GetNewestSites<Museum>(sites, 2);
            Assert.Contains(a, newSites);
            Assert.Contains(c, newSites);
        }
        [Fact]
        public void GetNewestSites_Get_Correct_Statues()
        {
            List<Site> sites = new List<Site>();
            Statue a = new Statue("a", "", "1", "", DateTime.Today, "AAA", "");
            Statue b = new Statue("b", "", "2", "", new DateTime(2002, 1, 1), "BBB", "");
            Statue c = new Statue("c", "", "3", "", new DateTime(2010, 1, 1), "BBB", "");
            

            sites.Add(a);
            sites.Add(b);
            sites.Add(c);

            List<Statue> newSites = TaskUtils.GetNewestSites<Statue>(sites, 1);
            Assert.Contains(a, newSites);
        }
    }
}