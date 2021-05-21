namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.posts", "Students_ID", c => c.Int());
            CreateIndex("dbo.posts", "Students_ID");
            AddForeignKey("dbo.posts", "Students_ID", "dbo.Students", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.posts", "Students_ID", "dbo.Students");
            DropIndex("dbo.posts", new[] { "Students_ID" });
            DropColumn("dbo.posts", "Students_ID");
        }
    }
}
