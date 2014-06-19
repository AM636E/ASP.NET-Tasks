using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Translator
{
    public class Country
    {
        public string CountryId { get; set; }
        public string Title { get; set; }

        public string Language { get; set; }
        public static IEnumerable<Translator.Country> GetCountries()
        {
            return null;
          /*  return from ri in
                       from ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                       select new RegionInfo(ci.LCID)
                   group ri by ri.TwoLetterISORegionName into g
                   orderby g.First().DisplayName
                   select new Translator.Country
                   {
                       CountryId = g.Key,
                       Title = g.First().DisplayName
                       Language = g.First().Laang
                   }
                   ;*/
        }
    }
}