namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attendd1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendances", "underObservation_from", c => c.DateTime());
            AlterColumn("dbo.Attendances", "underObservation_to", c => c.DateTime());
            AlterColumn("dbo.Attendances", "hosptital_from", c => c.DateTime());
            AlterColumn("dbo.Attendances", "hosptital_to", c => c.DateTime());
            AlterColumn("dbo.Attendances", "Absant_from", c => c.DateTime());
            AlterColumn("dbo.Attendances", "Absant_to", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "Absant_to", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Attendances", "Absant_from", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Attendances", "hosptital_to", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Attendances", "hosptital_from", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Attendances", "underObservation_to", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Attendances", "underObservation_from", c => c.DateTime(nullable: false));
        }
    }
}
