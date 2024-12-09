using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Services.DTOs
{
    public class CVDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public PersonalInformationDto PersonalInformationDto { get; set; } = null!;
        public ExperienceInformationDto ExperienceInformationDto { get; set; } = null!;

    }
}
