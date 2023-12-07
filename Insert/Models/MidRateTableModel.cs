using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insert.Models
{
    public class MidRateTableModel
    {
        public string TableName { get; set; }
        public string No { get; set; }
        public DateTime EffectiveDate { get; set; }
        public List<MidRateModel> Rates { get; set; }
    }
}