using CV_Manager.Domain;
using CV_Manager.Services.DTOs;
using CV_Manager.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Services.Services
{
    public class CVService
    {
        public CVService(ICVRepository cVRepository)
        {
            _CVRepository = cVRepository;
        }

        public readonly ICVRepository _CVRepository;

        public async Task<CVDto?> GetByIdAsync(int id)
        {
            var cv = await _CVRepository.GetByIdAsync(id);
            if (cv == null) return null;

            return new CVDto
            {
                Id = cv.Id,
                Name = cv.Name,
                PersonalInformation = new PersonalInformationDto
                {
                    Id = cv.PersonalInformation.Id,
                    CityName = cv.PersonalInformation.CityName,
                    Email = cv.PersonalInformation.Email,
                    FullName = cv.PersonalInformation.FullName,
                    MobileNumber = cv.PersonalInformation.MobileNumber
                },
                ExperienceInformation = new ExperienceInformationDto
                {
                    Id=cv.ExperienceInformation.Id,
                    City=cv.ExperienceInformation.City,
                    CompanyField=cv.ExperienceInformation.CompanyField,
                    CompanyName=cv.ExperienceInformation.CompanyName,
                }
            };
        }

        public async Task<IEnumerable<CVDto>> GetAllCVsAsync()
        {
            var cvs = await _CVRepository.GetAllAsync();
            return cvs.Select(cv => new CVDto
            {
                Id = cv.Id,
                Name = cv.Name,
                PersonalInformation = new PersonalInformationDto
                {
                    Id = cv.PersonalInformation.Id,
                    CityName = cv.PersonalInformation.CityName,
                    Email = cv.PersonalInformation.Email,
                    FullName = cv.PersonalInformation.FullName,
                    MobileNumber = cv.PersonalInformation.MobileNumber
                },
                ExperienceInformation = new ExperienceInformationDto
                {
                    Id = cv.ExperienceInformation.Id,
                    City = cv.ExperienceInformation.City,
                    CompanyField = cv.ExperienceInformation.CompanyField,
                    CompanyName = cv.ExperienceInformation.CompanyName,
                }
            });
        }

        public async Task AddAsync(CreateCVDto cvDto)
        {
            var cv = new CV
            {
                Name = cvDto.Name,
                PersonalInformationId = cvDto.PersonalInformationId,
                ExperienceInformationId = cvDto.ExperienceInformationId
                
            };

            await _CVRepository.AddAsync(cv);
        }

        public async Task UpdateCVAsync(UpdateCVDto cvDto)
        {
            var cv = await _CVRepository.GetByIdAsync(cvDto.Id);
            if (cv != null)
            {
                cv.Name = cvDto.Name;
                cv.PersonalInformationId = cvDto.PersonalInformationId;

                await _CVRepository.UpdateAsync(cv);
            }
        }

        public async Task DeleteCVAsync(int id)
        {
            await _CVRepository.DeleteAsync(id);
        }

    }
}
