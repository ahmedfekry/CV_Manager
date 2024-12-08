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
    public class PersonalInformationService
    {
        private readonly IPersonalInformationRepository _repository;

        public PersonalInformationService(IPersonalInformationRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonalInformationDto?> GetPersonalInfoByIdAsync(int id)
        {
            var info = await _repository.GetByIdAsync(id);
            if (info == null) return null;

            return new PersonalInformationDto
            {
                Id = info.Id,
                FullName = info.FullName,
                Email = info.Email,
                MobileNumber = info.MobileNumber,
                CityName = info.CityName
            };
        }

        public async Task<IEnumerable<PersonalInformationDto>> GetAllPersonalInfoAsync()
        {
            var infoList = await _repository.GetAllAsync();
            return infoList.Select(info => new PersonalInformationDto
            {
                Id = info.Id,
                FullName = info.FullName,
                Email = info.Email,
                MobileNumber = info.MobileNumber,
                CityName = info.CityName
            });
        }

        public async Task AddPersonalInfoAsync(CreatePersonalInformationDto dto)
        {
            var entity = new PersonalInformation
            {
                FullName = dto.FullName,
                Email = dto.Email,
                MobileNumber = dto.MobileNumber,
                CityName = dto.CityName
            };

            await _repository.AddAsync(entity);
        }

        public async Task UpdatePersonalInfoAsync(UpdatePersonalInformationDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity != null)
            {
                entity.FullName = dto.FullName;
                entity.Email = dto.Email;
                entity.MobileNumber = dto.MobileNumber;
                entity.CityName = dto.CityName; 

                await _repository.UpdateAsync(entity);
            }
        }

        public async Task DeletePersonalInfoAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
