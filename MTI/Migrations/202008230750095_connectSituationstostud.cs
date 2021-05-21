namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class connectSituationstostud : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Situations", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Situations", "StudentID");
            AddForeignKey("dbo.Situations", "StudentID", "dbo.Students", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Situations", "StudentID", "dbo.Students");
            DropIndex("dbo.Situations", new[] { "StudentID" });
            DropColumn("dbo.Situations", "StudentID");
        }
    }
}
