using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Insert.Entities;
using Insert.Migrations;

namespace Insert.Db
{
    public class InsertContext : DbContext
    {
        public InsertContext() : base("InsertContext")
        {
        }

        public DbSet<Rate> Rates { get; set; }
        public DbSet<RateTable> RateTables { get; set; }
        public DbSet<MidRate> MidRates { get; set; }
        public DbSet<MidRateTable> MidRateTables { get; set; }
    }
}