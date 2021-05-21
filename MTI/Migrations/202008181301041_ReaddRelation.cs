namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReaddRelation : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Relatives");
            AlterColumn("dbo.Relatives", "RelativeID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Relatives", "RelativeID");
            CreateIndex("dbo.Relatives", "RelativeID");
            AddForeignKey("dbo.Relatives", "RelativeID", "dbo.Students", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relatives", "RelativeID", "dbo.Students");
            DropIndex("dbo.Relatives", new[] { "RelativeID" });
            DropPrimaryKey("dbo.Relatives");
            AlterColumn("dbo.Relatives", "RelativeID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Relatives", "RelativeID");
        }
    }
}
