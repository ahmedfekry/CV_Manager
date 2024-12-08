using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Services.DTOs
{
    public class CreatePersonalInformationDto
    {
        [Required]
        public string FullName { get; set; } = null!;
        public string? CityName { get; set; }
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone number must contain only numeric digits.")]
        public string MobileNumber { get; set; } = null!;
    }
}
