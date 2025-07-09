namespace PortfolioWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContactModel : DbMigration
    {
        public override void Up()
        {
            
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
