using System.ComponentModel.DataAnnotations;

namespace NABD.DTO
{
    public class AddGuardianDto
    {
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Relationship { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }
    }
}
