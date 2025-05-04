using NABD.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NABD.DTO
{
    public class CreateToolDto
    {
        [Required, StringLength(100)]
        public string QrCode { get; set; }
        [Required]
        public string SerialNumber { get; set; }

        [ForeignKey(nameof(Patient))]
        public int? PatientId { get; set; }
    }
}
