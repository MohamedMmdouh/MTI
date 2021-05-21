namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reward1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rewards", "Reward_reason", c => c.String(nullable: false));
            AddColumn("dbo.Rewards", "reward", c => c.String(nullable: false));
            DropColumn("dbo.Rewards", "crime");
            DropColumn("dbo.Rewards", "punshiment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rewards", "punshiment", c => c.String(nullable: false));
            AddColumn("dbo.Rewards", "crime", c => c.String(nullable: false));
            DropColumn("dbo.Rewards", "reward");
            DropColumn("dbo.Rewards", "Reward_reason");
        }
    }
}
