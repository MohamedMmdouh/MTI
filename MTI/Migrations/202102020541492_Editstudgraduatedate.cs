namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Editstudgraduatedate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "getindate", c => c.DateTime());
            AlterColumn("dbo.Students", "expectedgraduateddate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "expectedgraduateddate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "getindate", c => c.DateTime(nullable: false));
        }
    }
}
