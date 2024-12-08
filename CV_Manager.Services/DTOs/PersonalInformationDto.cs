using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Services.DTOs
{
    public class PersonalInformationDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? CityName { get; set; }
        public string Email { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
    }
}
