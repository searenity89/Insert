using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Insert.Entities
{
    public class Rate: BaseEntity
    {
        [ForeignKey("RateTable")]
        public int RateTableId { get; set; }
        public virtual RateTable RateTable { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
    }
}