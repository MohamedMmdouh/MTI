namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Readdqualifica : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Qualification", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Qualification");
        }
    }
}
