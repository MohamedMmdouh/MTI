namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teamrelative : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Team", c => c.String());
            AddColumn("dbo.Relatives", "mothername", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Relatives", "mothername");
            DropColumn("dbo.Students", "Team");
        }
    }
}
