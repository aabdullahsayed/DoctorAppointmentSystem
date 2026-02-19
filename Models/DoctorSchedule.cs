using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class DoctorSchedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; } 
        [Required]
        public TimeSpan EndTime { get; set; }   

        
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }
    }
}