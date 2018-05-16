namespace CableWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillDetailsModels",
                c => new
                    {
                        BID = c.Long(nullable: false, identity: true),
                        CustomerID = c.Long(),
                        NoBox = c.Int(nullable: false),
                        SetupBoxBill = c.String(),
                        BillNo = c.Int(nullable: false),
                        BillDate = c.DateTime(),
                        CustomerName = c.String(),
                        Address = c.String(),
                        Mbno1 = c.String(),
                        Area = c.String(),
                        CMonth = c.String(),
                        MonthCharge = c.Decimal(precision: 18, scale: 2),
                        CGSTPer = c.Decimal(precision: 18, scale: 2),
                        CGSTAmt = c.Decimal(precision: 18, scale: 2),
                        SGSTPer = c.Decimal(precision: 18, scale: 2),
                        SGSTAmt = c.Decimal(precision: 18, scale: 2),
                        GrandTot = c.Decimal(precision: 18, scale: 2),
                        OldBal = c.Decimal(precision: 18, scale: 2),
                        PayableAmt = c.Decimal(precision: 18, scale: 2),
                        Dtfrom = c.DateTime(),
                        PMonth = c.String(),
                        ToDate = c.String(),
                        Disc = c.Decimal(precision: 18, scale: 2),
                        PaidAmt = c.Decimal(precision: 18, scale: 2),
                        PayDate = c.String(),
                        PaidAmt1 = c.Decimal(precision: 18, scale: 2),
                        PayDate1 = c.String(),
                        Balance = c.Decimal(precision: 18, scale: 2),
                        AgentId = c.Long(nullable: false),
                        AgentName = c.String(),
                        RegNo = c.String(),
                        CYear = c.String(),
                        CashDet = c.String(),
                        PayStat = c.String(),
                        CompanyId = c.String(),
                        AccNoBox = c.Decimal(precision: 18, scale: 2),
                        PackageName = c.String(),
                    })
                .PrimaryKey(t => t.BID);
            
            CreateTable(
                "dbo.CDateModels",
                c => new
                    {
                        CD = c.Long(nullable: false, identity: true),
                        CDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CD);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CDateModels");
            DropTable("dbo.BillDetailsModels");
        }
    }
}
