using System.Collections.Generic;

namespace PriceMonitoring.Models
{
    internal class Source
    {
        // buildings Bucha
        public static IEnumerable<string> SourсeListBucha
        {
            get
            {
                var sourceListBucha = new List<string>
                {
                    // page=1
                    "https://novostroyki.lun.ua/uk/%D0%BD%D0%BE%D0%B2%D0%BE%D0%B1%D1%83%D0%B4%D0%BE%D0%B2%D0%B8-%D0%B1%D1%83%D1%87%D1%96"
                };
                return sourceListBucha;
            }
        }

        // buildings Irpin
        public static IEnumerable<string> SourсeListIrpin
        {
            get
            {
                var sourceListIrpin = new List<string>
                {
                    // page=1
                    "https://novostroyki.lun.ua/uk/%D0%BD%D0%BE%D0%B2%D0%BE%D0%B1%D1%83%D0%B4%D0%BE%D0%B2%D0%B8-%D1%96%D1%80%D0%BF%D1%96%D0%BD%D1%8F",
                    // page=2
                    "https://novostroyki.lun.ua/uk/%D0%BD%D0%BE%D0%B2%D0%BE%D0%B1%D1%83%D0%B4%D0%BE%D0%B2%D0%B8-%D1%96%D1%80%D0%BF%D1%96%D0%BD%D1%8F?page=2",
                    // page=3
                    "https://novostroyki.lun.ua/uk/%D0%BD%D0%BE%D0%B2%D0%BE%D0%B1%D1%83%D0%B4%D0%BE%D0%B2%D0%B8-%D1%96%D1%80%D0%BF%D1%96%D0%BD%D1%8F?page=3",
                    // page=4
                    "https://novostroyki.lun.ua/uk/%D0%BD%D0%BE%D0%B2%D0%BE%D0%B1%D1%83%D0%B4%D0%BE%D0%B2%D0%B8-%D1%96%D1%80%D0%BF%D1%96%D0%BD%D1%8F?page=4"
                };
                return sourceListIrpin;
            }
        }
    }
}