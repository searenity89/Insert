using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Xml.Linq;

namespace Insert.Entities
{
    public class BaseTableEntity : BaseEntity
    {
        public DateTime EffectiveDate { get; set; }
        public TableType TableType { get; set; }
    }
}