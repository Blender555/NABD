using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NABD.Models.Domain
{
    public class Patient
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string SSN { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required,Phone]
        public string PhoneNumber { get; set; }
        public byte[]? PersonalImage { get; set; }


        public Tool Tool { get; set; } //1:1
        public MedicalHistory MedicalHistory { get; set; } //1:1
        public ICollection<PatientDoctor> PatientDoctors { get; set; } = new HashSet<PatientDoctor>(); //M:M
        public ICollection<PatientGuardian> PatientGuardians { get; set; } = new HashSet<PatientGuardian>(); //M:M
        public ICollection<Report> Reports { get; set; } = new HashSet<Report>(); //1:M
        public ICollection<Emergency> Emergencies { get; set; } = new HashSet<Emergency>(); //1:M
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>(); //1:M
    }
}
