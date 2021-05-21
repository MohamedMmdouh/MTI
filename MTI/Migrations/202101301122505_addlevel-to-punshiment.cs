namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addleveltopunshiment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.punishments", "level", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.punishments", "level");
        }
    }
}
