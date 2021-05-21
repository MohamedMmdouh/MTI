namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeenum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Qualification", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Religion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Religion", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Qualification", c => c.Int(nullable: false));
        }
    }
}
