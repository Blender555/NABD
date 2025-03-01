using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NABD.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Gender { get; set; }  

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string NationalId { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string UserType { get; set; }

        public string? Specialty { get; set; }
    }
}
