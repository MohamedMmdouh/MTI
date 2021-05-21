namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernamelogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UsernameViwer", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UsernameViwer");
        }
    }
}
