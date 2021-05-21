namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newsss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Date");
        }
    }
}
