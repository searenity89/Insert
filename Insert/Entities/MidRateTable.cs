using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insert.Entities
{
    public class MidRateTable: BaseTableEntity
    {
        public string TableName { get; set; }
        public string No { get; set; }
        public List<MidRate> Rates { get; set; }
    }
}