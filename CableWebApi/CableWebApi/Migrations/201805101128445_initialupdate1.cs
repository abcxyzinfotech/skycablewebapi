namespace CableWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialupdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BillDetailsModels", "BillDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BillDetailsModels", "BillDate", c => c.DateTime());
        }
    }
}
