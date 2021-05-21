namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelativeRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Relatives", "Student_ID", c => c.Int());
            CreateIndex("dbo.Relatives", "Student_ID");
            AddForeignKey("dbo.Relatives", "Student_ID", "dbo.Students", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relatives", "Student_ID", "dbo.Students");
            DropIndex("dbo.Relatives", new[] { "Student_ID" });
            DropColumn("dbo.Relatives", "Student_ID");
        }
    }
}
