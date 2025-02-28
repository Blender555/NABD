using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NABD.Models.Domain
{
    public class Tool
    {
        public int Id { get; set; }

        [Range(0, 100)]
        public int OxygenSaturation { get; set; } = 98;

        [Range(30, 45)]
        public float BodyTemperature { get; set; } = 37.0f;

        public DateTime VitalDataTimestamp { get; set; } = DateTime.UtcNow;

        [Range(40, 180)]
        public int HeartRate { get; set; } = 70;

        [Required, StringLength(100)]
        public string QrCode { get; set; }
        [ForeignKey(nameof(Patient))]
        public int? PatientId { get; set; }
        public Patient Patient { get; set; } //1:1
        public ICollection<Emergency> Emergencies { get; set; } = new HashSet<Emergency>(); //1:M
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>(); //1:M
    }
}
