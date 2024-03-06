using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.Models
{
    public class Registrations
    {
        [Key]
        public int RegistrationID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        // Add other properties as needed
        public virtual Students? Student { get; set; }
        public virtual Courses? Course { get; set; }
    }


}
