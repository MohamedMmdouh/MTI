namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatequalif : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Qualifications", "qualigetdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Qualifications", "qualigetdate", c => c.String(nullable: false));
        }
    }
}
