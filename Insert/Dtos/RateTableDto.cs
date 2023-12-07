using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insert.Dtos
{
    public class RateTableDto
    {
        public string Table { get; set; }
        public string No { get; set; }
        public DateTime TradingDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public List<RateDto> Rates { get; set; }
    }
}