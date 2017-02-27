using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace PriceMonitoring.Models
{
    public class DownloadDom
    {
        public List<IHtmlDocument> DocumentListIrpin { get; private set; }
        public List<IHtmlDocument> DocumentListBucha { get; private set; }

        public DownloadDom()
        {
            // Download site DOM  Bucha Buildings
            DocumentListBucha = DownloadSiteDom(Source.SourсeListBucha);
            // Download site DOM  Irpin Buildings
            DocumentListIrpin = DownloadSiteDom(Source.SourсeListIrpin);
        }

        private static List<IHtmlDocument> DownloadSiteDom(IEnumerable<string> sourceList)
        {
            var documentList = new List<IHtmlDocument>();
            foreach (var item in sourceList)
            {
                var htmlParser = new HtmlParser();
                var siteList = new List<string>();
                using (var webClient = new WebClient {Encoding = Encoding.UTF8})
                {
                    // combine https + site name
                    var downloadResult = webClient.DownloadString(item);
                    var document = htmlParser.Parse(downloadResult);
                    var resultFindList = document.QuerySelectorAll("a.no-decor");
                    siteList.AddRange(resultFindList.Select(item2 => $"https://novostroyki.lun.ua{item2.GetAttribute("href")}"));
                    // download site DOM
                    foreach (var item3 in siteList)
                    {
                        var downloadResult2 = webClient.DownloadString(item3);
                        documentList.Add(htmlParser.Parse(downloadResult2));
                        Console.OutputEncoding = Encoding.UTF8;
                        Console.WriteLine($"Site {item3}........ok!");
                    }
                }
            }
            return documentList;
        }
    }
}
