namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class city : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cities", "Students_ID", c => c.Int());
            AddColumn("dbo.Students", "cityID", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Cities_ID", c => c.Int());
            CreateIndex("dbo.cities", "Students_ID");
            CreateIndex("dbo.Students", "Cities_ID");
            AddForeignKey("dbo.Students", "Cities_ID", "dbo.cities", "ID");
            AddForeignKey("dbo.cities", "Students_ID", "dbo.Students", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cities", "Students_ID", "dbo.Students");
            DropForeignKey("dbo.Students", "Cities_ID", "dbo.cities");
            DropIndex("dbo.Students", new[] { "Cities_ID" });
            DropIndex("dbo.cities", new[] { "Students_ID" });
            DropColumn("dbo.Students", "Cities_ID");
            DropColumn("dbo.Students", "cityID");
            DropColumn("dbo.cities", "Students_ID");
        }
    }
}
