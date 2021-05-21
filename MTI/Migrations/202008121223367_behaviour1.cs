namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class behaviour1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "behaviour", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "behavioue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "behavioue", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "behaviour");
        }
    }
}
