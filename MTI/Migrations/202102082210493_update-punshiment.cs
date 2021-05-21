namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepunshiment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.punishments", "order", c => c.Int(nullable: false));
            AddColumn("dbo.punishments", "remove", c => c.Boolean(nullable: false));
            AddColumn("dbo.punishments", "alert", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.punishments", "alert");
            DropColumn("dbo.punishments", "remove");
            DropColumn("dbo.punishments", "order");
        }
    }
}
