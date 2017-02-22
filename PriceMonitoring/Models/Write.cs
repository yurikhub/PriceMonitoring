using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

namespace PriceMonitoring.Models
{
    class Write
    {
        public static void WriteToExcel(IEnumerable<Building> buildingsBucha, IEnumerable<Building> buildingsIrpen)
        {
            //Create aplication
            Console.WriteLine("Creating Microsoft Excel document... ");
            var app = new Application();
            var doc = app.Workbooks.Add();

            // Creating sheet Буча
            Console.WriteLine("Creating sheet Буча...");
            var listNameBucha = "Буча";
            CreateSheet(buildingsBucha, app, listNameBucha);

            //// Creating sheet Ірпінь
            Console.WriteLine("Creating sheet Ірпінь...");
            var listNameIrpin = "Ірпінь";
            CreateSheet(buildingsIrpen, app, listNameIrpin);

            // Save and close
            doc.SaveAs($@"{Environment.CurrentDirectory}\info_{DateTime.Now.ToShortDateString()}.xlsx");
            doc.Close();
            app.Quit();
        }

        private static void CreateSheet(IEnumerable<Building> buildingsBucha, Application app, string listName)
        {
            var workSheet = app.Worksheets.Add();
            // Create table title
            workSheet.Name = listName;
            CreateTableTitle(workSheet);
            // Create rows
            CreateRows(buildingsBucha, workSheet);
        }

        private static void CreateTableTitle(dynamic workSheet)
        {
            workSheet.Cells[1, "A"] = "№";
            workSheet.Cells[1, "B"] = "Назва";
            workSheet.Cells[1, "C"] = "Адреса";
            workSheet.Cells[1, "D"] = "Cайт";
            workSheet.Cells[1, "E"] = "Ціна за м2, від (грн)";
            workSheet.Cells[1, "F"] = "Дата оновлення";
            workSheet.Cells[1, "G"] = "Дата перевірки";
        }

        private static void CreateRows(IEnumerable<Building> buildingsBucha, dynamic workSheet)
        {
            var row = 1;
            foreach (var item in buildingsBucha)
            {
                row++;
                workSheet.Cells[row, "A"] = item.Id;
                workSheet.Cells[row, "B"] = item.BuildingName;
                workSheet.Cells[row, "C"] = item.BuldingAddress;
                workSheet.Hyperlinks.Add(workSheet.Cells[row, "D"], $"http://www.{item.BuildingSite}/", Type.Missing,
                    "Click to open", item.BuildingSite);
                workSheet.Cells[row, "E"] = item.Price;
                workSheet.Cells[row, "F"] = item.UpdateDate;
                workSheet.Cells[row, "G"] = item.CurrentDate;
            }

            workSheet.Range["A1", $"G{row}"].AutoFormat(XlRangeAutoFormat.xlRangeAutoFormatTable10,
                true, false, true, true, true, true);

        }
    }
}
