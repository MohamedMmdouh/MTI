namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grades : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.punishments", "MinusGrades", c => c.Int(nullable: false));
            AlterColumn("dbo.Rewards", "plusGrades", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rewards", "plusGrades", c => c.String(nullable: false));
            AlterColumn("dbo.punishments", "MinusGrades", c => c.String(nullable: false));
        }
    }
}
