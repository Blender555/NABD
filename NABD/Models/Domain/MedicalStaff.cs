using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NABD.Models.Domain
{
    public class MedicalStaff
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public int SSN { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Role { get; set; } 
        public byte[]? PersonalImage { get; set; }

        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>(); //1:M
        public ICollection<Report> Reports { get; set; } = new HashSet<Report>(); //1:M
        public ICollection<Emergency> Emergencies { get; set; } = new HashSet<Emergency>(); //1:M
    }
    public class Doctor : MedicalStaff
    {
        [Required, StringLength(100)]
        public string Specialization { get; set; }

        public ICollection<PatientDoctor> PatientDoctors { get; set; } = new HashSet<PatientDoctor>(); //M:M
        public ICollection<Nurse> Nurses { get; set; } = new HashSet<Nurse>(); //1:M
    }
    public enum ShiftType
    {
        Morning,
        Afternoon,
        Night
    }

    public class Nurse : MedicalStaff
    {
        [Required]
        public string Ward { get; set; }
        [Required]
        public ShiftType Shift { get; set; }
        [ForeignKey(nameof(Doctor))]
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; } //M:1
    }
}
