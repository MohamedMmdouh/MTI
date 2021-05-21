namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checker1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
       "dbo.AbsantDetails",
       c => new
       {
           ID = c.Int(nullable: false, identity: true),
           Department = c.String(nullable: false),
           Studname = c.String(nullable: false),
           daily_attendance_ID = c.Int(),
       })
       .PrimaryKey(t => t.ID)
       .ForeignKey("dbo.daily_attendance", t => t.daily_attendance_ID)
       .Index(t => t.daily_attendance_ID);

            CreateTable(
                "dbo.daily_attendance",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Total = c.Int(nullable: false),
                    AttendeesNum = c.Int(nullable: false),
                    AbsentNum = c.Int(nullable: false),
                    Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Sections",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Level = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Shootings",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Trainingname = c.String(nullable: false),
                    numofbullet = c.Int(nullable: false),
                    weaponname = c.String(nullable: false),
                    numofsuccessshots = c.Int(nullable: false),
                    Grade = c.String(nullable: false),
                    ShootigErrors = c.String(),
                    Dateofshoot = c.DateTime(nullable: false),
                    StudentID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);

            CreateTable(
                "dbo.Students",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    StudentNumber = c.Int(nullable: false),
                    Name = c.String(nullable: false),
                    SectionID = c.Int(nullable: false),
                    SpecializationID = c.Int(nullable: false),
                    Religion = c.String(nullable: false),
                    Nationality = c.String(nullable: false),
                    SSN = c.String(nullable: false, maxLength: 14),
                    Mobile = c.String(nullable: false, maxLength: 11),
                    Blood_Type = c.String(nullable: false),
                    BirthDate = c.DateTime(nullable: false),
                    Address = c.String(nullable: false),
                    Email = c.String(),
                    Image = c.String(),
                    Fasila = c.String(nullable: false),
                    saria = c.String(nullable: false),
                    Katiba = c.String(nullable: false),
                    IsVIsible = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: true)
                .ForeignKey("dbo.specializations", t => t.SpecializationID, cascadeDelete: true)
                .Index(t => t.SectionID)
                .Index(t => t.SpecializationID);

            CreateTable(
                "dbo.specializations",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    specialty = c.String(),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserRoles", t => t.userRoles_ID)
                .Index(t => t.userRoles_ID);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
        }
        
        public override void Down()
        {
        }
    }
}
