using System;
using System.IO;
using System.Collections.Generic;

namespace LD4
{
    //PRADINES LENTELES ATSKIROS, CSV FORMATAS, KITOKIO TIPO ISSIMTIS

    /// <summary>
    /// Main web form class
    /// </summary>
    public partial class Form1 : System.Web.UI.Page
    {
        
        private string results1;
        private string results2;
        private string resultsTxt;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            results1 = Server.MapPath("/App_Data/PaminklaiAutorius.csv");
            results2 = Server.MapPath("/App_Data/Nauji.csv");
            resultsTxt = Server.MapPath("/App_Data/Rez.txt");
            if(File.Exists(resultsTxt))
            {
                File.Delete(resultsTxt);
            }

            divData.Visible = false;
            divResults.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsText(TextBox1, Label2))
            {
                try
                {
                    //List<Site> sites = InOutUtils.ReadSites(Directory.GetFiles(Server.MapPath("App_Data"), "*.txt"));
                    List<Tuple<string, List<Site>>> sites = InOutUtils.ReadSites(Directory.GetFiles(Server.MapPath("App_Data"), "*.txt"));
                    List<Site> sitesMerged = TaskUtils.GetMergedSites(sites);

                    ShowData(sites, false, "Miestas", "Vadovas", "Pavadinimas", "Gatvė",
                   "Data", "Autorius/Tipas", "Darbo D./Paminklo pav.", "Turi gidą", "Bilieto kaina");

                    Label1.Text = "Lankytinų vietų, turinčių gidus, skaičius: " + TaskUtils.GetGuidesCount(sitesMerged);


                    List<Site> visitableOnWeekend = TaskUtils.GetVisitableOnWeekend(sitesMerged);
                    ShowTypes(visitableOnWeekend, Table2);

                    List<Site> filteredByAuthor = TaskUtils.GetStatuesByAuthor(sitesMerged, TextBox1.Text);
                    InOutUtils.PrintToCsvFile(filteredByAuthor, results1, "Pavadinimas,Gatvė,Data,Autorius,Paminklo pav.");
                    ShowData(filteredByAuthor, Table3, true, "Pavadinimas", "Gatvė", "Data", "Autorius", "Paminklo pav.");


                    List<Museum> newestMuseums = TaskUtils.GetNewestSites<Museum>(sitesMerged, 2);
                    List<Statue> newestStatues = TaskUtils.GetNewestSites<Statue>(sitesMerged, 1);

                    newestMuseums.Sort();
                    newestStatues.Sort();

                    List<Site> newestMerged = new List<Site>();
                    newestMerged.AddRange(newestMuseums);
                    newestMerged.AddRange(newestStatues);

                    InOutUtils.PrintToCsvFile(newestMerged, results2, "Pavadinimas,Gatvė,Data,Autorius/Tipas,Darbo D./Paminklo pav,Turi gidą,Bilieto kaina");
                    ShowData(newestMerged, Table4, true, "Pavadinimas", "Gatvė",
                       "Data", "Autorius/Tipas", "Darbo D./Paminklo pav.", "Turi gidą", "Bilieto kaina");


                    InOutUtils.PrintToTxtFile(sites, resultsTxt, " failas:",
                        String.Format("| {0, -10} | {1, -20} | {2, -15} | {3,-20} | {4, -10} | {5,-10} | {6,-10} | {7,-5} | {8, -5} |",
                        "Miestas", "Vadovas", "Pavadinimas", "Gatvė", "Data", "Aut./Tip.", " D.D./Pav.", "Gidas", "Kaina"));
                    InOutUtils.PrintToTxtFile(visitableOnWeekend, resultsTxt, "Dirba savaitgaliais:",
                        String.Format("| {0, -10} | {1, -20} | {2, -15} | {3,-20} | {4, -10} | {5,-10} | {6,-10} | {7,-5} | {8, -5} |",
                        "Miestas", "Vadovas", "Pavadinimas", "Gatvė", "Data", "Tipas", " D.D.", "Gidas", "Kaina"));
                    InOutUtils.PrintToTxtFile(filteredByAuthor, resultsTxt, "Atrinkta pagal autorių:",
                        String.Format("| {0, -10} | {1, -20} | {2, -15} | {3,-20} | {4, -10} | {5,-10} | {6,-10} |",
                        "Miestas", "Vadovas", "Pavadinimas", "Gatvė", "Data", "Autorius", "P. Pav"));
                    InOutUtils.PrintToTxtFile(newestMerged, resultsTxt, "Naujausios vietovės:",
                        String.Format("| {0, -10} | {1, -20} | {2, -15} | {3,-20} | {4, -10} | {5,-10} | {6,-10} | {7,-5} | {8, -5} |",
                        "Miestas", "Vadovas", "Pavadinimas", "Gatvė", "Data", "Aut./Tip.", " D.D./Pav.", "Gidas", "Kaina"));
                    divData.Visible = true;
                    divResults.Visible = true;
                }
                catch (Exception ex)
                {
                    Label3.Visible = true;
                    Label3.Text = ex.Message;
                }  
            }
        }

        
    }
}