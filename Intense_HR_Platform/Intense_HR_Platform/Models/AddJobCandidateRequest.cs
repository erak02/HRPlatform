using System.ComponentModel.DataAnnotations;

namespace Intense_HR_Platform.Models
{
    public class AddJobCandidateRequest
    {
        // Separate adding candidates to prevent exposing the Skills and Id navigation properties in the swagger
        [Required]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
