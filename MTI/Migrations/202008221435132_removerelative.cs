namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerelative : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Relatives", "ID", "dbo.Students");
            DropIndex("dbo.Relatives", new[] { "ID" });
            DropTable("dbo.Relatives");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Relatives",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Relativename = c.String(nullable: false),
                        Relationship = c.String(nullable: false),
                        RelativeNum = c.String(nullable: false),
                        Job = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Numofbrothers = c.Int(nullable: false),
                        NumAmongBrothers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Relatives", "ID");
            AddForeignKey("dbo.Relatives", "ID", "dbo.Students", "ID");
        }
    }
}
