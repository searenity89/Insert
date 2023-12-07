namespace Insert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MidRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MidRateTableId = c.Int(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MidRateTables", t => t.MidRateTableId, cascadeDelete: true)
                .Index(t => t.MidRateTableId);
            
            CreateTable(
                "dbo.MidRateTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TableName = c.String(),
                        No = c.String(),
                        EffectiveDate = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RateTableId = c.Int(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Bid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ask = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RateTables", t => t.RateTableId, cascadeDelete: true)
                .Index(t => t.RateTableId);
            
            CreateTable(
                "dbo.RateTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TableName = c.String(),
                        No = c.String(),
                        TradingDate = c.DateTime(nullable: false),
                        EffectiveDate = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rates", "RateTableId", "dbo.RateTables");
            DropForeignKey("dbo.MidRates", "MidRateTableId", "dbo.MidRateTables");
            DropIndex("dbo.Rates", new[] { "RateTableId" });
            DropIndex("dbo.MidRates", new[] { "MidRateTableId" });
            DropTable("dbo.RateTables");
            DropTable("dbo.Rates");
            DropTable("dbo.MidRateTables");
            DropTable("dbo.MidRates");
        }
    }
}
