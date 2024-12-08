using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Services.DTOs
{
    public class CreateExperienceInformationDto
    {
        [Required]
        [MaxLength(20)]
        public string CompanyName { get; set; }
        public string? City { get; set; }
        public String? CompanyField { get; set; }
    }
}
