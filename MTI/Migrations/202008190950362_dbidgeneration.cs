namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbidgeneration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Relatives", new[] { "RelativeID" });
            DropPrimaryKey("dbo.Relatives");
            AlterColumn("dbo.Relatives", "RelativeID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Relatives", "RelativeID");
            CreateIndex("dbo.Relatives", "RelativeID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Relatives", new[] { "RelativeID" });
            DropPrimaryKey("dbo.Relatives");
            AlterColumn("dbo.Relatives", "RelativeID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Relatives", "RelativeID");
            CreateIndex("dbo.Relatives", "RelativeID");
        }
    }
}
