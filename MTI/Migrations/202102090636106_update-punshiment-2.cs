namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepunshiment2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.punishments", "order", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.punishments", "order", c => c.Int(nullable: false));
        }
    }
}
