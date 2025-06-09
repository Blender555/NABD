namespace NABD.DTO
{
    public class AddReportDto
    {
        public DateTime UploadDate { get; set; }
        public string Diagnosis { get; set; }
        public string Medication { get; set; }
        public int PatientId { get; set; }
        public int MedicalStaffId { get; set; }
    }
}
