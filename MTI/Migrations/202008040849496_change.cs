namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "userRoles_ID", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "userRoles_ID" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                        UserRoleID = c.Int(nullable: false),
                        userRoles_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RolesType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Users", "userRoles_ID");
            AddForeignKey("dbo.Users", "userRoles_ID", "dbo.UserRoles", "ID");
        }
    }
}
