using System.ComponentModel.DataAnnotations;

namespace PortfolioWebApp.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Percentage { get; set; }
        public string ColorCode { get; set; }
    }
}
