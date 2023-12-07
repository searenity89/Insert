using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insert.Dtos
{
    public class RateDto
    {
        public string Currency { get; set; }
        public string Code { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }   
    }
}