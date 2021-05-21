namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEnumQulaifications1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "qualification");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "qualification", c => c.Int(nullable: false));
        }
    }
}
