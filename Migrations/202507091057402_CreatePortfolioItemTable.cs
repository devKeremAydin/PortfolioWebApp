namespace PortfolioWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePortfolioItemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PortfolioItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PortfolioItems");
        }
    }
}
