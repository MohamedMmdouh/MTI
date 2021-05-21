namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "secondNum", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "secondNum");
        }
    }
}
