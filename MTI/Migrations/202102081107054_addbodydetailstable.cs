namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbodydetailstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.bodydetails",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        weight = c.Single(nullable: false),
                        height = c.Single(nullable: false),
                        bodysymmetry = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.ID)
                .Index(t => t.ID);
            
            AddColumn("dbo.Relatives", "Relativeaddress", c => c.String(nullable: false));
            DropColumn("dbo.Students", "weight");
            DropColumn("dbo.Students", "height");
            DropColumn("dbo.Students", "bodysymmetry");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "bodysymmetry", c => c.Single(nullable: false));
            AddColumn("dbo.Students", "height", c => c.Single(nullable: false));
            AddColumn("dbo.Students", "weight", c => c.Single(nullable: false));
            DropForeignKey("dbo.bodydetails", "ID", "dbo.Students");
            DropIndex("dbo.bodydetails", new[] { "ID" });
            DropColumn("dbo.Relatives", "Relativeaddress");
            DropTable("dbo.bodydetails");
        }
    }
}
