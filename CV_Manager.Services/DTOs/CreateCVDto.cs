﻿using System;
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
        [Required]
        public int PersonalInformationId { get; set; }
        [Required]
        public int ExperienceInformationId { get; set; }
    }
}