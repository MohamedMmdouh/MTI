namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "graduatedate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "graduatedate", c => c.DateTime(nullable: false));
        }
    }
}
