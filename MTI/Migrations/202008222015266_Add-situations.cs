namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addsituations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Situations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SituationType = c.String(nullable: false),
                        Details = c.String(nullable: false),
                        procedure = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Situations");
        }
    }
}
