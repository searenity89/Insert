using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insert.Entities
{
    public class RateTable: BaseTableEntity
    {
        public string TableName { get; set; }
        public string No { get; set; }
        public DateTime TradingDate { get; set; }
        public virtual IList<Rate> Rates { get; set; }
    }
}