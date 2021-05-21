namespace MTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbatch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        batchNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Batches");
        }
    }
}
