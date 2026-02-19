using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        
        [Required]
        public string Department { get; set; } 
        public List<DoctorSchedule>? Schedules { get; set; }
    }
}