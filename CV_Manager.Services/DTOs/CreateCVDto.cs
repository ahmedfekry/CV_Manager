using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Services.DTOs
{
    public class CreateCVDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public CreateExperienceInformationDto ExperienceInformationDto { get; set; }
        public CreatePersonalInformationDto PersonalInformationDto { get; set; }

    }
}
