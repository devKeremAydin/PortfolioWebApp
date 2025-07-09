using System.ComponentModel.DataAnnotations;

namespace PortfolioWebApp.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Number { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
