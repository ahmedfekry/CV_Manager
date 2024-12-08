using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Domain
{
    public class ExperienceInformation
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string City   { get; set; }
        public string CompanyField { get; set; }

        public CV CV { get; set; }
    }
}
