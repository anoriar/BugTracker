namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Issues", new[] { "ProjectId" });
            RenameColumn(table: "dbo.Issues", name: "UserId", newName: "DeveloperId");
            RenameIndex(table: "dbo.Issues", name: "IX_UserId", newName: "IX_DeveloperId");
            CreateTable(
                "dbo.IssueCreateModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeveloperId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IssueDetailModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Developer = c.String(),
                        Status = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Issues", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Issues", "ProjectId");
            AddForeignKey("dbo.Issues", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Issues", new[] { "ProjectId" });
            AlterColumn("dbo.Issues", "ProjectId", c => c.Int());
            DropTable("dbo.IssueDetailModels");
            DropTable("dbo.IssueCreateModels");
            RenameIndex(table: "dbo.Issues", name: "IX_DeveloperId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Issues", name: "DeveloperId", newName: "UserId");
            CreateIndex("dbo.Issues", "ProjectId");
            AddForeignKey("dbo.Issues", "ProjectId", "dbo.Projects", "Id");
        }
    }
}
