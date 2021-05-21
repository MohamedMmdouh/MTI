namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batches", "Students_ID", c => c.Int());
            CreateIndex("dbo.Batches", "Students_ID");
            AddForeignKey("dbo.Batches", "Students_ID", "dbo.Students", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Batches", "Students_ID", "dbo.Students");
            DropIndex("dbo.Batches", new[] { "Students_ID" });
            DropColumn("dbo.Batches", "Students_ID");
        }
    }
}
