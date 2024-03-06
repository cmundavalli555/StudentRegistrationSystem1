using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.Models
{
    public class Courses
    {
        [Key]
        public int CourseID { get;internal set; }
        
        [MaxLength(10)]
        [DisplayName(nameof(CourseID))]
        public string? CourseName { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName(nameof(CourseName))]
        [Range(1, 10)]
        public string? CourseDescription { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName(nameof(CourseDescription))]
        [Range(1, 10)]
        // Add other properties as needed
        public virtual ICollection<Registrations>? Registrations { get; set; }
    }

}
