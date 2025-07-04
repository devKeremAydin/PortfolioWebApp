using System.Data.Entity;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
