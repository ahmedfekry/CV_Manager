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
        public CVService(ICVRepository cVRepository,
                         IPersonalInformationRepository personalInformationRepository,
                         IExperienceInformationRepository experienceInformationRepository)
        {
            _CVRepository = cVRepository;
            this._personalInformationRepository = personalInformationRepository;
            this._experienceInformationRepository = experienceInformationRepository;
        }

        public readonly ICVRepository _CVRepository;
        private readonly IPersonalInformationRepository _personalInformationRepository;
        private readonly IExperienceInformationRepository _experienceInformationRepository;

        public async Task<CVDto?> GetByIdAsync(int id)
        {
            var cv = await _CVRepository.GetByIdAsync(id);
            if (cv == null) return null;

            return new CVDto
            {
                Id = cv.Id,
                Name = cv.Name,
                PersonalInformationDto = new PersonalInformationDto
                {
                    Id = cv.PersonalInformation.Id,
                    CityName = cv.PersonalInformation.CityName,
                    Email = cv.PersonalInformation.Email,
                    FullName = cv.PersonalInformation.FullName,
                    MobileNumber = cv.PersonalInformation.MobileNumber
                },
                ExperienceInformationDto = new ExperienceInformationDto
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
                PersonalInformationDto = new PersonalInformationDto
                {
                    Id = cv.PersonalInformation.Id,
                    CityName = cv.PersonalInformation.CityName,
                    Email = cv.PersonalInformation.Email,
                    FullName = cv.PersonalInformation.FullName,
                    MobileNumber = cv.PersonalInformation.MobileNumber
                },
                ExperienceInformationDto = new ExperienceInformationDto
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
            var personalInformation = new PersonalInformation
            {
                CityName = cvDto.PersonalInformationDto.CityName,
                Email = cvDto.PersonalInformationDto.Email,
                FullName = cvDto.PersonalInformationDto.FullName,
                MobileNumber = cvDto.PersonalInformationDto.MobileNumber
            };

            await _personalInformationRepository.AddAsync(personalInformation);

            var experienceInformation = new ExperienceInformation
            {
                CompanyName = cvDto.ExperienceInformationDto.CompanyName,
                CompanyField = cvDto.ExperienceInformationDto.CompanyField,
                City = cvDto.ExperienceInformationDto.City
            };

            await _experienceInformationRepository.AddAsync(experienceInformation);

            var cv = new CV
            {
                Name = cvDto.Name,
                PersonalInformationId = personalInformation.Id,
                ExperienceInformationId = experienceInformation.Id
                
            };

            await _CVRepository.AddAsync(cv);
        }

        public async Task UpdateCVAsync(UpdateCVDto cvDto)
        {
            var cv = await _CVRepository.GetByIdAsync(cvDto.Id);
            if (cv != null)
            {
                cv.Name = cvDto.Name;
                await _CVRepository.UpdateAsync(cv);


                var personalInformation = await _personalInformationRepository.GetByIdAsync(cv.PersonalInformationId);
                if (personalInformation != null)
                {
                    personalInformation.MobileNumber = cvDto.PersonalInformationDto.MobileNumber;
                    personalInformation.CityName = cvDto.PersonalInformationDto.CityName;
                    personalInformation.Email = cvDto.PersonalInformationDto.Email;
                    personalInformation.FullName = cvDto.PersonalInformationDto.FullName;

                    await _personalInformationRepository.UpdateAsync(personalInformation);
                }

                var experientInformation = await _experienceInformationRepository.GetByIdAsync(cv.ExperienceInformationId);
                if (experientInformation != null)
                {
                    experientInformation.City = cvDto.ExperienceInformationDto.City;
                    experientInformation.CompanyName = cvDto.ExperienceInformationDto.CompanyName;
                    experientInformation.City = cvDto.ExperienceInformationDto?.City;
                    experientInformation.CompanyField = cvDto.ExperienceInformationDto?.CompanyField;

                    await _experienceInformationRepository.UpdateAsync(experientInformation);
                }

            }
        }

        public async Task DeleteCVAsync(int id)
        {
            await _CVRepository.DeleteAsync(id);
        }

    }
}
