namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATESTUDENT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "joindate", c => c.DateTime());
            AddColumn("dbo.Students", "main_specialization", c => c.String(nullable: false));
            AddColumn("dbo.Students", "armyspecialization", c => c.String(nullable: false));
            AddColumn("dbo.Students", "group", c => c.String(nullable: false));
            AddColumn("dbo.Students", "weight", c => c.Single(nullable: false));
            AddColumn("dbo.Students", "height", c => c.Single(nullable: false));
            AddColumn("dbo.Students", "bodysymmetry", c => c.Single(nullable: false));
            AddColumn("dbo.Relatives", "fathername", c => c.String(nullable: false));
            AddColumn("dbo.Relatives", "fatherJob", c => c.String(nullable: false));
            AddColumn("dbo.Relatives", "fatherqualification", c => c.String(nullable: false));
            AddColumn("dbo.Relatives", "mothername", c => c.String(nullable: false));
            AddColumn("dbo.Relatives", "mothernum", c => c.String(nullable: false, maxLength: 11));
            AddColumn("dbo.Relatives", "motherJob", c => c.String(nullable: false));
            AddColumn("dbo.Relatives", "motherqualification", c => c.String(nullable: false));
            AddColumn("dbo.Relatives", "Responsable", c => c.String(nullable: false));
            AddColumn("dbo.Relatives", "ResponsableNum", c => c.String(nullable: false, maxLength: 11));
            AddColumn("dbo.Relatives", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Relatives", "ResponsableJob", c => c.String(nullable: false));
            AddColumn("dbo.Relatives", "JobAddress", c => c.String(nullable: false));
            AddColumn("dbo.Relatives", "TotalSalary", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "getindate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Students", "expectedgraduateddate");
            DropColumn("dbo.Students", "Team");
            DropColumn("dbo.Relatives", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Relatives", "Status", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Team", c => c.String());
            AddColumn("dbo.Students", "expectedgraduateddate", c => c.DateTime());
            AlterColumn("dbo.Students", "getindate", c => c.DateTime());
            DropColumn("dbo.Relatives", "TotalSalary");
            DropColumn("dbo.Relatives", "JobAddress");
            DropColumn("dbo.Relatives", "ResponsableJob");
            DropColumn("dbo.Relatives", "Address");
            DropColumn("dbo.Relatives", "ResponsableNum");
            DropColumn("dbo.Relatives", "Responsable");
            DropColumn("dbo.Relatives", "motherqualification");
            DropColumn("dbo.Relatives", "motherJob");
            DropColumn("dbo.Relatives", "mothernum");
            DropColumn("dbo.Relatives", "mothername");
            DropColumn("dbo.Relatives", "fatherqualification");
            DropColumn("dbo.Relatives", "fatherJob");
            DropColumn("dbo.Relatives", "fathername");
            DropColumn("dbo.Students", "bodysymmetry");
            DropColumn("dbo.Students", "height");
            DropColumn("dbo.Students", "weight");
            DropColumn("dbo.Students", "group");
            DropColumn("dbo.Students", "armyspecialization");
            DropColumn("dbo.Students", "main_specialization");
            DropColumn("dbo.Students", "joindate");
        }
    }
}
