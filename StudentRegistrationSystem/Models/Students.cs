using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.Models
{
    public class Students
    {
        [Key]
        public int StudentID { get;internal  set; }
        
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName(nameof(FirstName))]
        [Range(1, 10)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName(nameof(LastName))]
        [Range(1, 10)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName(nameof(Email))]
        [Range(1, 10)]
        public string? Phonenumber { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName(nameof(Phonenumber))]
        [Range(1, 10)]
        // Add other properties as needed
        public virtual ICollection<Registrations>? Registrations { get; set; }
    }
}
