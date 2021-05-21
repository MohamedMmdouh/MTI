namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class punshimantstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.punishments", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.punishments", "Status");
        }
    }
}
