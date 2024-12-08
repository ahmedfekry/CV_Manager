using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Services.DTOs
{
    public class UpdateCVDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PersonalInformationId { get; set; }
        public int ExperienceInformationId { get; set; }
    }
}
