namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cityandpoststring : DbMigration
    {
        public override void Up()
        {
          
            AddColumn("dbo.Students", "City", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Post", c => c.String(nullable: false));
           
        }

        public override void Down()
        {
            AddColumn("dbo.Students", "postid", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "cityid", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "Post");
            DropColumn("dbo.Students", "City");
            CreateIndex("dbo.Students", "postid");
            CreateIndex("dbo.Students", "cityid");
            AddForeignKey("dbo.Students", "postid", "dbo.posts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Students", "cityid", "dbo.cities", "ID", cascadeDelete: true);
        }
    }
}
