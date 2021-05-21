namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkerrr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Discriminator");
        }
    }
}
