namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cityandposts : DbMigration
    {
        public override void Up()
        {

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "cityid", "dbo.cities");
            DropIndex("dbo.Students", new[] { "postid" });
            DropIndex("dbo.Students", new[] { "cityid" });
            AlterColumn("dbo.Students", "cityid", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "cityid", newName: "Cities_ID");
            AddColumn("dbo.Students", "cityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "Cities_ID");
            CreateIndex("dbo.Students", "postID");
            AddForeignKey("dbo.Students", "Cities_ID", "dbo.cities", "ID");
        }
    }
}
