namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRelative : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Relatives", "Student_ID", "dbo.Students");
            DropIndex("dbo.Relatives", new[] { "Student_ID" });
            DropTable("dbo.Relatives");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Relatives",
                c => new
                    {
                        RelativeID = c.Int(nullable: false, identity: true),
                        Relativename = c.String(nullable: false),
                        Relationship = c.String(nullable: false),
                        RelativeNum = c.String(nullable: false),
                        Job = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Numofbrothers = c.Int(nullable: false),
                        NumAmongBrothers = c.Int(nullable: false),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.RelativeID);
            
            CreateIndex("dbo.Relatives", "Student_ID");
            AddForeignKey("dbo.Relatives", "Student_ID", "dbo.Students", "ID");
        }
    }
}
