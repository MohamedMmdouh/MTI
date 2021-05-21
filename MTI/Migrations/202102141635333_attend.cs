namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attend : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Clinic_type = c.String(),
                        underObservation_from = c.DateTime(),
                        underObservation_to = c.DateTime(),
                        hosptital_from = c.DateTime(),
                        hosptital_to = c.DateTime(),
                        Absant_from = c.DateTime(),
                        Absant_to = c.DateTime(),
                        lec_absant = c.Boolean(nullable: false),
                        recovery = c.Boolean(nullable: false),
                        Details = c.String(),
                        Totalminusgrade = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "StudentID", "dbo.Students");
            DropIndex("dbo.Attendances", new[] { "StudentID" });
            DropTable("dbo.Attendances");
        }
    }
}
