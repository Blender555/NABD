﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NABD.Models.Domain
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
        [Required, MaxLength(1000)]
        public string? Diagnosis { get; set; }
        [MaxLength(500)]
        public string? Medication { get; set; }

        [ForeignKey(nameof(Patient))]
        public int? PatientId { get; set; }
        public Patient Patient { get; set; } //M:1

        [ForeignKey(nameof(Doctor))]
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; } //M:1
    }
}
