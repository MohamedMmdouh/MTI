namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cityandpost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "city", c => c.String(nullable: false));
            AddColumn("dbo.Students", "post", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "post");
            DropColumn("dbo.Students", "city");
        }
    }
}
