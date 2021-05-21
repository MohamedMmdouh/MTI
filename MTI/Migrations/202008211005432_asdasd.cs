namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasd : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Discriminator", c => c.String());
            RenameColumn(table: "dbo.Students", name: "Discriminator", newName: "Discriminator1");
            AddColumn("dbo.Students", "Discriminator", c => c.String());
        }
    }
}
