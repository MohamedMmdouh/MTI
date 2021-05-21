namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poskkk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Cities_ID", "dbo.cities");
            DropForeignKey("dbo.cities", "Students_ID", "dbo.Students");
            DropForeignKey("dbo.Students", "postID", "dbo.posts");
            DropForeignKey("dbo.posts", "Students_ID", "dbo.Students");
            DropIndex("dbo.cities", new[] { "Students_ID" });
            DropIndex("dbo.posts", new[] { "Students_ID" });
            DropIndex("dbo.Students", new[] { "Cities_ID" });
            DropColumn("dbo.cities", "Students_ID");
            DropColumn("dbo.posts", "Students_ID");
            DropColumn("dbo.Students", "cityID");
            DropColumn("dbo.Students", "Cities_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Cities_ID", c => c.Int());
            AddColumn("dbo.Students", "postID", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "cityID", c => c.Int(nullable: false));
            AddColumn("dbo.posts", "Students_ID", c => c.Int());
            AddColumn("dbo.cities", "Students_ID", c => c.Int());
            CreateIndex("dbo.Students", "Cities_ID");
            CreateIndex("dbo.Students", "postID");
            CreateIndex("dbo.posts", "Students_ID");
            CreateIndex("dbo.cities", "Students_ID");
            AddForeignKey("dbo.posts", "Students_ID", "dbo.Students", "ID");
            AddForeignKey("dbo.Students", "postID", "dbo.posts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.cities", "Students_ID", "dbo.Students", "ID");
            AddForeignKey("dbo.Students", "Cities_ID", "dbo.cities", "ID");
        }
    }
}
