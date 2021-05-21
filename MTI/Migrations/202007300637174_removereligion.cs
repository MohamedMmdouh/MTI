namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removereligion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "Religion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Religion", c => c.Int(nullable: false));
        }
    }
}
