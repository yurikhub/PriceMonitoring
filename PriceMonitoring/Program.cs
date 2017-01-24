using System;
using System.Net;
using PriceMonitoring.Models;

namespace PriceMonitoring
{
    class Program
    {
        static void Main()
        {
            Console.Title = "PriceMonitoring";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Download source code......");

            try
            {
                var downloadDom = new DownloadDom();
                var parser = new Parser(downloadDom.DocumentListBucha, downloadDom.DocumentListIrpin);
                Write.WriteToExcel(parser.ObjectListBucha, parser.ObjectListIrpin);

            }
            catch (WebException)
            {

                Console.WriteLine("No internet conection!");
                Console.ReadKey();
            }
           
        }
    }
}
