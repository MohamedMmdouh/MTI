namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "PlaceofBirth", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "PlaceofBirth");
        }
    }
}
