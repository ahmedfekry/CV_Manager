using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Domain
{
    public class CV
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonalInformationId { get; set; }
        public PersonalInformation PersonalInformation { get; set; } = null!;
        public int ExperienceInformationId { get; set; }
        public ExperienceInformation ExperienceInformation { get; set; } = null!;
    }
}
