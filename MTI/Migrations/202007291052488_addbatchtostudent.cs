namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbatchtostudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "batchid", c => c.Int(nullable: true));
            CreateIndex("dbo.Students", "batchid");
            AddForeignKey("dbo.Students", "batchid", "dbo.Batches", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "batchid", "dbo.Batches");
            DropIndex("dbo.Students", new[] { "batchid" });
            DropColumn("dbo.Students", "batchid");
        }
    }
}
