namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatesofgraduation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "getindate", c => c.DateTime());
            AddColumn("dbo.Students", "expectedgraduateddate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "expectedgraduateddate");
            DropColumn("dbo.Students", "getindate");
        }
    }
}
