namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checker : DbMigration
    {
        public override void Up()
        {

            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Users", "userRoles_ID", "dbo.UserRoles");
            DropForeignKey("dbo.Students", "SpecializationID", "dbo.specializations");
            DropForeignKey("dbo.Shootings", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Students", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AbsantDetails", "daily_attendance_ID", "dbo.daily_attendance");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "userRoles_ID" });
            DropIndex("dbo.Students", new[] { "SpecializationID" });
            DropIndex("dbo.Students", new[] { "SectionID" });
            DropIndex("dbo.Shootings", new[] { "StudentID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AbsantDetails", new[] { "daily_attendance_ID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.specializations");
            DropTable("dbo.Students");
            DropTable("dbo.Shootings");
            DropTable("dbo.Sections");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.daily_attendance");
            DropTable("dbo.AbsantDetails");
        }
    }
}
