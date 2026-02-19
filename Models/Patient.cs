using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? Phone { get; set; } 
        
        public string? BloodGroup { get; set; } 
        
        public DateTime DateOfBirth { get; set; }

        public List<Appointment>? Appointments { get; set; } 
    }
}