namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasdss : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
