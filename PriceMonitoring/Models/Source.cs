using System.Collections.Generic;

namespace PriceMonitoring.Models
{
    internal static class Source
    {
        // buildings Bucha
        public static IEnumerable<string> SourсeListBucha()
        {
            var site =
                "https://novostroyki.lun.ua/uk/%D0%BD%D0%BE%D0%B2%D0%BE%D0%B1%D1%83%D0%B4%D0%BE%D0%B2%D0%B8-%D0%B1%D1%83%D1%87%D1%96";

            yield return site;
        }

        // buildings Irpin
        public static IEnumerable<string> SourсeListIrpin()
        {
            var site =
                "https://novostroyki.lun.ua/uk/%D0%BD%D0%BE%D0%B2%D0%BE%D0%B1%D1%83%D0%B4%D0%BE%D0%B2%D0%B8-%D1%96%D1%80%D0%BF%D1%96%D0%BD%D1%8F?page=";
            for (var i = 1; i <= 4; i++)
            {
                yield return $"{site}{i}";
            }
        }
    }
}