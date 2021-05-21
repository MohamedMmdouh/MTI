namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attachments1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        Attachmenttype = c.String(nullable: false),
                        Organization = c.String(nullable: false),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attachments", "StudentID", "dbo.Students");
            DropIndex("dbo.Attachments", new[] { "StudentID" });
            DropTable("dbo.Attachments");
        }
    }
}
