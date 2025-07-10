using System.Collections.Generic;

namespace PortfolioWebApp.Models
{
    public class HomeViewModel
    {
        // Proje listesi (Portfolio bölümü için)
        public List<PortfolioItem> PortfolioItems { get; set; }

        // Yetenek listesi (Skills bölümü için)
        public List<Skill> Skills { get; set; }
    }
}
