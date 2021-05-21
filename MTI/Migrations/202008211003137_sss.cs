namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "Discriminator");

        }

        public override void Down()
        {
            
        }
    }
}
