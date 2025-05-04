using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NABD.Models.Domain
{
    public class Tool
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string QrCode { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        [ForeignKey(nameof(Patient))]
        public int? PatientId { get; set; }
        public Patient? Patient { get; set; } // 1:1

        public ICollection<Emergency> Emergencies { get; set; } = new HashSet<Emergency>(); // 1:M
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>(); // 1:M
        public ICollection<MQTTMessage> MQTTMessages { get; set; } = new HashSet<MQTTMessage>(); // 1:M

        // New Status Property
        [Required]
        public ToolStatus Status { get; set; } = ToolStatus.Active; // Default value
    }

    // Enum for Tool Status
    public enum ToolStatus
    {
        Active,
        Inactive,
        Maintenance
    }
}

