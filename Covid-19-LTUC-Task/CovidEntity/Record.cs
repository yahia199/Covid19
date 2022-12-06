using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidEntity
{
    class Country
    {
        public Guid Id { get; set; }
        public string CountryName { get; set; }
        public int TotalConfirmedCases { get; set; }
        public int TotalConfirmedDeaths { get; set; }
        public int TotalRecoveredCases { get; set; }
        public DateTime Date { get; set; }


    }
}
