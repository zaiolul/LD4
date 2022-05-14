using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace LD4
{
    public partial class Form1 : System.Web.UI.Page
    {
        /// <summary>
        /// Shows data on the page by creating a table for each file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="excludeCity"></param>
        /// <param name="headers"></param>
        protected void ShowData<T>(List<Tuple<string, List<T>>> data, bool excludeCity, params string[] headers)
        {
            foreach(var entry in data)
            {
                Table table = new Table();
                Label label = new Label();
                divData.Controls.Add(new LiteralControl("<br/>"));
                label.Text = entry.Item1;
                divData.Controls.Add(label);
                divData.Controls.Add(table);
                ShowData<T>(entry.Item2, table, false, headers);
               
            }
        }
        /// <summary>
        /// Method to display a table of data on the page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="table"></param>
        /// <param name="excludeCity"></param>
        /// <param name="headers"></param>
        protected void ShowData<T>(List<T> data, Table table, bool excludeCity, params string[] headers)
        {
            TableHeaderRow headerRow = new TableHeaderRow();
            foreach (string header in headers)
            {
                CreateHeaderCell(header, headerRow, HorizontalAlign.Center);
            }

            table.Rows.Add(headerRow);
            foreach (T entry in data)
            {
                string[] parts;
                TableRow row = new TableRow();
                  
                parts = entry.ToString().Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if(!excludeCity)
                {
                    for (int i = 0; i < parts.Length; i++)
                    {
                        CreateCell(parts[i].Trim(), row, HorizontalAlign.Center);
                    }
                }
                else
                {
                    for (int i = 2; i < parts.Length; i++)
                    {
                        CreateCell(parts[i].Trim(), row, HorizontalAlign.Center);
                    }
                }
                
                table.Rows.Add(row);
            }
        }
        /// <summary>
        /// Methdos for dipslaying a table of cities and types of sites on the page
        /// </summary>
        /// <param name="data"></param>
        /// <param name="table"></param>
        protected void ShowTypes(List<Site> data, Table table)
        {
            TableHeaderRow headerRow = new TableHeaderRow();
           
            CreateHeaderCell("Miestas", headerRow, HorizontalAlign.Center);
            CreateHeaderCell("Tipas", headerRow, HorizontalAlign.Center);

            table.Rows.Add(headerRow);
            foreach (Site entry in data)
            {
                TableRow row = new TableRow();

                CreateCell(entry.City, row, HorizontalAlign.Center);
                CreateCell(((Museum)entry).Type, row, HorizontalAlign.Center);
                table.Rows.Add(row);
            }
        }
        /// <summary>
        /// Method for creating a table cell
        /// </summary>
        /// <param name="text"></param>
        /// <param name="row"></param>
        /// <param name="align"></param>
        protected void CreateCell(string text, TableRow row, HorizontalAlign align)
        {
            TableCell cell = new TableCell();

            cell.Text = text;


            cell.HorizontalAlign = align;
            row.Cells.Add(cell);
        }
        /// <summary>
        /// Methdod for creating a table header cell
        /// </summary>
        /// <param name="text"></param>
        /// <param name="row"></param>
        /// <param name="align"></param>
        protected void CreateHeaderCell(string text, TableHeaderRow row, HorizontalAlign align)
        {
            TableHeaderCell cell = new TableHeaderCell();

            cell.Text = text;


            cell.HorizontalAlign = align;
            row.Cells.Add(cell);
        }
        /// <summary>
        /// Checks if a textbox isn't empty and changes given label text accordingly
        /// </summary>
        /// <param name="box"></param>
        /// <param name="label"></param>
        /// <returns>true if text box contains text, false otherwise</returns>
        public bool IsText(TextBox box, Label label)
        {
            string text = box.Text;
            label.Text = "";
            if (text == String.Empty)
            {
                label.Visible = true;
                label.Text = "Teksto laukas negali būti tuščias.";
                return false;
            }
           
            return true;
        }
       
    }
}