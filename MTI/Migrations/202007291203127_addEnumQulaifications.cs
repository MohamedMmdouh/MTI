namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEnumQulaifications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "qualification", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "GPA", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "GPA");
            DropColumn("dbo.Students", "qualification");
        }
    }
}
