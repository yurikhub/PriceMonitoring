using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;

namespace PriceMonitoring.Models
{
    internal class Parser
    {
        public List<Building> ObjectListIrpin { get; private set; }
        public List<Building> ObjectListBucha { get; private set; }

        public Parser(IEnumerable<IHtmlDocument> documentListBucha, IEnumerable<IHtmlDocument> documentListIrpen)
        {
            ////////////// BUCHA /////////////

            #region Parse Bucha

            // Lists for add data
            var siteQueryBucha = new List<string>();
            var nameQueryBucha = new List<string>();
            var addressQueryBucha = new List<string>();
            var priceQueryBucha = new List<string>();
            var updateDateQueryBucha = new List<string>();
            // Parsing documents
            ParseDocuments(documentListBucha, nameQueryBucha, addressQueryBucha, siteQueryBucha, priceQueryBucha,
                updateDateQueryBucha);
            // Create list Building objects building
            var buchaList = new List<Building>();
            CreateListBuldings(buchaList, nameQueryBucha, addressQueryBucha, siteQueryBucha, priceQueryBucha,
                updateDateQueryBucha);
            ObjectListBucha = buchaList;

            #endregion

            ////////////// IRPIN /////////////

            #region Parse Irpin

            // Lists for add data
            var siteQueryIrpin = new List<string>();
            var nameQueryIrpin = new List<string>();
            var addressQueryIrpin = new List<string>();
            var priceQueryIrpin = new List<string>();
            var updateDateQueryIrpin = new List<string>();
            // Parsing documents
            ParseDocuments(documentListIrpen, nameQueryIrpin, addressQueryIrpin, siteQueryIrpin, priceQueryIrpin,
                updateDateQueryIrpin);
            // Create list Building objects building
            var irpinList = new List<Building>();
            CreateListBuldings(irpinList, nameQueryIrpin, addressQueryIrpin, siteQueryIrpin, priceQueryIrpin,
                updateDateQueryIrpin);
            ObjectListIrpin = irpinList;

            #endregion
        }

        #region  ParseDocuments method 

        private static void ParseDocuments(IEnumerable<IHtmlDocument> documentList, List<string> buildingNameQuery,
            List<string> buildingAddressQuery, List<string> buildingSiteQuery, List<string> buildingPriceQuery,
            List<string> buildingUpdateDateQuery)
        {
            foreach (var item in documentList)
            {
                //Query building name
                var resultFindListName = item.QuerySelectorAll("h1.page-header__text");
                buildingNameQuery.AddRange(resultFindListName.Select(i => i.TextContent.Trim()));

                //Query building address
                var resultFindListAddress =
                    item.QuerySelectorAll("div.key-value-list>div.key-value-item:nth-child(5)>div.value");
                if (resultFindListAddress.Length == 0)
                    buildingAddressQuery.Add("Немає адреси");
                else
                    buildingAddressQuery.AddRange(resultFindListAddress.Select(i => i.TextContent.Trim()));

                // Query building site
                var resultFindListSite = item.QuerySelectorAll("noindex>a");
                if (resultFindListSite.Length == 0)
                    buildingSiteQuery.Add("no_link");
                else
                    buildingSiteQuery.AddRange(resultFindListSite.Select(i => i.TextContent.Trim()));

                //Query building price
                var resultFindListPrice = item.QuerySelectorAll("meta[itemprop=\"price\"]");
                if (resultFindListPrice.Length == 0)
                    buildingPriceQuery.Add("Продажі не почалися");
                else
                    buildingPriceQuery.AddRange(resultFindListPrice.Select(x => x.GetAttribute("content")));
                
                //Query building  update date
                var resultFindListUpdateDate = item.QuerySelectorAll("span.b-update-label");
                if (resultFindListUpdateDate.Length == 0)
                    buildingUpdateDateQuery.Add("Продажі не почалися");
                else
                    buildingUpdateDateQuery.AddRange(
                        resultFindListUpdateDate.Select(i => i.TextContent.Replace("Ціна перевірена", "").Trim()));
            }
        }

        #endregion

        #region CreateListBuldings method

        private static void CreateListBuldings(ICollection<Building> buldingList,
            IEnumerable<string> nameQuery, IReadOnlyList<string> addressQuery, IReadOnlyList<string> siteQuery,
            IReadOnlyList<string> priceQuery,
            IReadOnlyList<string> updateDateQuery)
        {
            var currentDate = DateTime.Now.ToString(@"dd.MM.yy  HH:mm");
            var idcounter = 1;
            int addresscounter = 0, pricecounter = 0, sitecounter = 0, datecounter = 0;
            foreach (var item in nameQuery)
                buldingList.Add(new Building
                {
                    Id = idcounter++,
                    BuildingName = item,
                    BuldingAddress = addressQuery[addresscounter++],
                    BuildingSite = siteQuery[sitecounter++],
                    Price = priceQuery[pricecounter++],
                    UpdateDate = updateDateQuery[datecounter++],
                    CurrentDate = currentDate
                });
        }

        #endregion
    }
}