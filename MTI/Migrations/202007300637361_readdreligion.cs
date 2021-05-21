namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readdreligion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Religion", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Religion");
        }
    }
}
