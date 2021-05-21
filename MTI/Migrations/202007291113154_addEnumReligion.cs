namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEnumReligion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Religion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Religion", c => c.String(nullable: false));
        }
    }
}
