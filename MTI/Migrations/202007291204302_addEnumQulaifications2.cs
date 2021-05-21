namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEnumQulaifications2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "qualification", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "qualification");
        }
    }
}
