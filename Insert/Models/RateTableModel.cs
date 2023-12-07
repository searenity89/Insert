using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insert.Models
{
    public class RateTableModel
    {
        public string TableName { get; set; }
        public string No { get; set; }
        public DateTime TradingDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public List<RateModel> Rates { get; set; }
        public TableType TableType { get; set; }
    }
}