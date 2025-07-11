namespace PortfolioWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColorToSkills : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "ColorCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "ColorCode");
        }
    }
}
