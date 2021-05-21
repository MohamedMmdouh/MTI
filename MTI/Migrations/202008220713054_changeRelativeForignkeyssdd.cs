namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeRelativeForignkeyssdd : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Relatives", name: "RelativeID", newName: "ID");
            RenameIndex(table: "dbo.Relatives", name: "IX_RelativeID", newName: "IX_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Relatives", name: "IX_ID", newName: "IX_RelativeID");
            RenameColumn(table: "dbo.Relatives", name: "ID", newName: "RelativeID");
        }
    }
}
