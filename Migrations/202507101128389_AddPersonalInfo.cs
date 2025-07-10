namespace PortfolioWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonalInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        ProfileImagePath = c.String(),
                        CvPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonalInfoes");
        }
    }
}
