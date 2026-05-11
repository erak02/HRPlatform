using System.ComponentModel.DataAnnotations;

namespace Intense_HR_Platform.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
