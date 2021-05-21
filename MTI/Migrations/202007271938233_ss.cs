namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
