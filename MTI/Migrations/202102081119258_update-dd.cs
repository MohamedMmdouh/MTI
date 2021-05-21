namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Qualification", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Qualification", c => c.String(nullable: false));
        }
    }
}
