namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shootinglevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shootings", "level", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shootings", "level");
        }
    }
}
