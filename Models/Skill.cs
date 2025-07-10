using System.ComponentModel.DataAnnotations;

namespace PortfolioWebApp.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Skill name is required.")]
        public string Name { get; set; }

        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
        public int Percentage { get; set; }

        // Skill bar'ının rengi için (örneğin: "#FF5733" veya "blue" gibi CSS uyumlu renk)
        public string Color { get; set; }
    }
}
