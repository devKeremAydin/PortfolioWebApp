namespace PortfolioWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAboutTextToPersonalInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalInfoes", "AboutText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalInfoes", "AboutText");
        }
    }
}
