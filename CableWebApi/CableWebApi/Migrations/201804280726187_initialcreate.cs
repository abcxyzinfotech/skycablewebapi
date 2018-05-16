namespace CableWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminPinModels",
                c => new
                    {
                        srno = c.Long(nullable: false, identity: true),
                        AdminPin = c.String(),
                    })
                .PrimaryKey(t => t.srno);
            
            CreateTable(
                "dbo.AgentModels",
                c => new
                    {
                        Aid = c.Long(nullable: false, identity: true),
                        AgentId = c.Int(),
                        AgentName = c.String(),
                        UserEmail = c.String(),
                        Password = c.String(),
                        CompanyId = c.String(),
                    })
                .PrimaryKey(t => t.Aid);
            
            CreateTable(
                "dbo.AreaModels",
                c => new
                    {
                        AreaId = c.Long(nullable: false, identity: true),
                        Area = c.String(),
                        CompanyId = c.String(),
                    })
                .PrimaryKey(t => t.AreaId);
            
            CreateTable(
                "dbo.CompanyMasterModels",
                c => new
                    {
                        Srno = c.Long(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyAddress = c.String(),
                        CompanyMobNo = c.String(),
                        CompanyEmailId = c.String(),
                        CompanyGSTNo = c.String(),
                        CompanyLogo = c.Binary(),
                        AccountNo = c.String(),
                        IFSC = c.String(),
                        WihGST = c.String(),
                        GSTinout = c.String(),
                        CompanyId = c.Long(),
                        RemarkBill = c.String(),
                    })
                .PrimaryKey(t => t.Srno);
            
            CreateTable(
                "dbo.DatabaseNameModels",
                c => new
                    {
                        Srno = c.Long(nullable: false, identity: true),
                        MyServerName = c.String(),
                        MyDatabaseName = c.String(),
                        MyPath = c.String(),
                    })
                .PrimaryKey(t => t.Srno);
            
            CreateTable(
                "dbo.FormNameModels",
                c => new
                    {
                        Srno = c.Long(nullable: false, identity: true),
                        Status = c.Int(),
                        FieldName = c.String(),
                    })
                .PrimaryKey(t => t.Srno);
            
            CreateTable(
                "dbo.LoginViewModels",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        UserType = c.String(),
                        CompanyId = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.packageModels",
                c => new
                    {
                        PID = c.Long(nullable: false, identity: true),
                        Package = c.String(),
                        Rate = c.Decimal(precision: 18, scale: 2),
                        CompanyId = c.String(),
                    })
                .PrimaryKey(t => t.PID);
            
            CreateTable(
                "dbo.ReconnectModels",
                c => new
                    {
                        RID = c.Long(nullable: false, identity: true),
                        CustId = c.Long(),
                        MacId = c.String(),
                        ReconDate = c.DateTime(),
                        DiscDate = c.DateTime(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        CompanyId = c.String(),
                    })
                .PrimaryKey(t => t.RID);
            
            CreateTable(
                "dbo.RegModels",
                c => new
                    {
                        CID = c.Long(nullable: false, identity: true),
                        CustomerID = c.Long(nullable: false),
                        NoBox = c.Decimal(precision: 18, scale: 0),
                        SetupNoReg = c.String(),
                        ConsumerName = c.String(),
                        Address = c.String(),
                        LandMark = c.String(),
                        Mbno1 = c.String(),
                        Mbno2 = c.String(),
                        Area = c.String(),
                        AgentId = c.Long(),
                        AgentName = c.String(),
                        Phone = c.String(),
                        CGSTPer = c.Decimal(precision: 18, scale: 2),
                        CSGTAmt = c.Decimal(precision: 18, scale: 2),
                        SGSTPer = c.Decimal(precision: 18, scale: 2),
                        SGSTAmt = c.Decimal(precision: 18, scale: 2),
                        TotRate = c.Decimal(precision: 18, scale: 2),
                        Dics = c.String(),
                        TotAmt = c.Decimal(precision: 18, scale: 2),
                        CustBal = c.Decimal(precision: 18, scale: 0),
                        RegNo = c.String(),
                        Type = c.String(),
                        ImgP1 = c.Binary(),
                        ImgP2 = c.Binary(),
                        ImgP3 = c.Binary(),
                        IDProof = c.String(),
                        DtFrom = c.DateTime(),
                        CNameMarathi = c.String(),
                        UserName = c.String(),
                        CustPassword = c.String(),
                        ChangeCol = c.String(),
                        NotifyStat = c.Int(),
                        Remark = c.String(),
                        CompanyId = c.String(),
                        AccNoBox = c.Decimal(precision: 18, scale: 0),
                        PackageName = c.String(),
                        CDate = c.DateTime(),
                        CTime = c.String(),
                    })
                .PrimaryKey(t => t.CID);
            
            CreateTable(
                "dbo.SetupDetailModels",
                c => new
                    {
                        SID = c.Long(nullable: false, identity: true),
                        CustomerID = c.Long(),
                        Setboxno = c.String(),
                        SDate = c.String(),
                        FormNo = c.String(),
                        Packeges = c.String(),
                        Rate = c.Decimal(precision: 18, scale: 2),
                        Disc = c.Decimal(precision: 18, scale: 2),
                        Amt = c.Decimal(precision: 18, scale: 2),
                        CardNo = c.Decimal(precision: 18, scale: 2),
                        FaultyNo = c.String(),
                        StatType = c.String(),
                        CompanyId = c.String(),
                    })
                .PrimaryKey(t => t.SID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SetupDetailModels");
            DropTable("dbo.RegModels");
            DropTable("dbo.ReconnectModels");
            DropTable("dbo.packageModels");
            DropTable("dbo.LoginViewModels");
            DropTable("dbo.FormNameModels");
            DropTable("dbo.DatabaseNameModels");
            DropTable("dbo.CompanyMasterModels");
            DropTable("dbo.AreaModels");
            DropTable("dbo.AgentModels");
            DropTable("dbo.AdminPinModels");
        }
    }
}
