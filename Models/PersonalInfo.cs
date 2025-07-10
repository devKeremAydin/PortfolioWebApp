using System.ComponentModel.DataAnnotations;

namespace PortfolioWebApp.Models
{
    public class PersonalInfo
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ProfileImagePath { get; set; }

        public string CvPath { get; set; }
    }
}
