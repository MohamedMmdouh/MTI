namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Editrelative : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Relatives", "fatherNum", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Relatives", "RelativeNum", c => c.String(nullable: false, maxLength: 11));
            DropColumn("dbo.Relatives", "mothername");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Relatives", "mothername", c => c.String(nullable: false));
            AlterColumn("dbo.Relatives", "RelativeNum", c => c.String(nullable: false));
            DropColumn("dbo.Relatives", "fatherNum");
        }
    }
}
