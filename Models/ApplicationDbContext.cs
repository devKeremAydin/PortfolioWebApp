using System.Data.Entity;

namespace PortfolioWebApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }
    }
}
