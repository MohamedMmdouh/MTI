namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Messages1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Date");
        }
    }
}
