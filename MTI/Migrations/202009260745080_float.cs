namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _float : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.punishments", "MinusGrades", c => c.Single(nullable: false));
            AlterColumn("dbo.Students", "behaviour", c => c.Single(nullable: false));
            AlterColumn("dbo.Rewards", "plusGrades", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rewards", "plusGrades", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "behaviour", c => c.Int(nullable: false));
            AlterColumn("dbo.punishments", "MinusGrades", c => c.Int(nullable: false));
        }
    }
}
