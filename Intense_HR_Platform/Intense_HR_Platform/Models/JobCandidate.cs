using System.ComponentModel.DataAnnotations;

namespace Intense_HR_Platform.Models
{
    public class JobCandidate
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNo { get; set; }
        [Required]
        public string Email { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();
    }
}
