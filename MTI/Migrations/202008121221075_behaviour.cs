namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class behaviour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "behavioue", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "behavioue");
        }
    }
}
