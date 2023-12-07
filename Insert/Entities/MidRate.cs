using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Insert.Entities
{
    public class MidRate: BaseEntity
    {
        [ForeignKey("MidRateTable")]
        public int MidRateTableId { get; set; }
        public virtual MidRateTable MidRateTable { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
    }
}