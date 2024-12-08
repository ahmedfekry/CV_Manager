using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Domain
{
    public class PersonalInformation
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? CityName { get; set; } = null!;
        public string Email { get; set; }
        public string MobileNumber { get; set; }

        public CV CV { get; set; }
    }
}
