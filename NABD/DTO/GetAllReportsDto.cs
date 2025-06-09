namespace NABD.DTO
{
    public class GetAllReportsDto
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string Diagnosis { get; set; }
        public string Medication { get; set; }
    }
}
