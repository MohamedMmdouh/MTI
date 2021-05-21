namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReaddRelative : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => t.RelativeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Relatives");
        }
    }
}
