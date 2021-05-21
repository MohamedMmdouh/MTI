namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Fburl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Fburl");
        }
    }
}
