namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "cityofbirth", c => c.String(nullable: false));
            AlterColumn("dbo.Qualifications", "gpa", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Qualifications", "gpa", c => c.String(nullable: false));
            DropColumn("dbo.Students", "cityofbirth");
        }
    }
}
