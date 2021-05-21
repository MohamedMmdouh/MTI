namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RewardAndPunshiment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.punishments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        WhoApplyIt = c.String(nullable: false),
                        crime = c.String(nullable: false),
                        punshiment = c.String(nullable: false),
                        MinusGrades = c.String(nullable: false),
                        PunshimentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        WhoApplyIt = c.String(nullable: false),
                        crime = c.String(nullable: false),
                        punshiment = c.String(nullable: false),
                        plusGrades = c.String(nullable: false),
                        RewardDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rewards", "StudentID", "dbo.Students");
            DropForeignKey("dbo.punishments", "StudentID", "dbo.Students");
            DropIndex("dbo.Rewards", new[] { "StudentID" });
            DropIndex("dbo.punishments", new[] { "StudentID" });
            DropTable("dbo.Rewards");
            DropTable("dbo.punishments");
        }
    }
}
