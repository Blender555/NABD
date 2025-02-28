using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NABD.Models.Domain
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        [Required, MaxLength(1000)]
        public string ReportDetails { get; set; }
        [ForeignKey(nameof(Patient))]
        public int? PatientId { get; set; }
        public Patient Patient { get; set; } //M:1
        [ForeignKey(nameof(MedicalStaff))]
        public int? MedicalStaffId { get; set; }
        public MedicalStaff MedicalStaff { get; set; } //M:1
    }
}
