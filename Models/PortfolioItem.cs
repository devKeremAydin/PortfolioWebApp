using System.ComponentModel.DataAnnotations;

namespace PortfolioWebApp.Models
{
    public class PortfolioItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}
