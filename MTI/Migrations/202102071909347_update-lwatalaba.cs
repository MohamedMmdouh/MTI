namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelwatalaba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Qualification = c.String(nullable: false),
                        qualispecialize = c.String(nullable: false),
                        qualidepart = c.String(nullable: false),
                        qualigetdate = c.String(nullable: false),
                        gpa = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.ID)
                .Index(t => t.ID);
            
            AddColumn("dbo.Students", "grade", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "group", c => c.String());
            DropColumn("dbo.Students", "GPA");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "GPA", c => c.Int(nullable: false));
            DropForeignKey("dbo.Qualifications", "ID", "dbo.Students");
            DropIndex("dbo.Qualifications", new[] { "ID" });
            AlterColumn("dbo.Students", "group", c => c.String(nullable: false));
            DropColumn("dbo.Students", "grade");
            DropTable("dbo.Qualifications");
        }
    }
}
