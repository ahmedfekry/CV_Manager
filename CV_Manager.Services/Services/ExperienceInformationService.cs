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
    public class ExperienceInformationService
    {
        private readonly IExperienceInformationRepository _repository;

        public ExperienceInformationService(IExperienceInformationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ExperienceInformationDto?> GetExperienceInfoByIdAsync(int id)
        {
            var info = await _repository.GetByIdAsync(id);
            if (info == null) return null;

            return new ExperienceInformationDto
            {
                Id = info.Id,
                CompanyName = info.CompanyName,
                City = info.City,
                CompanyField = info.CompanyField
            };
        }

        public async Task<IEnumerable<ExperienceInformationDto>> GetAllExperienceInfoAsync()
        {
            var infoList = await _repository.GetAllAsync();
            return infoList.Select(info => new ExperienceInformationDto
            {
                Id = info.Id,
                CompanyName = info.CompanyName,
                City = info.City,
                CompanyField = info.CompanyField
            });
        }

        public async Task AddExperienceInfoAsync(CreateExperienceInformationDto dto)
        {
            var entity = new ExperienceInformation
            {
                City = dto.City,
                CompanyName = dto.CompanyName,
                CompanyField = dto.CompanyField
            };

            await _repository.AddAsync(entity);
        }

        public async Task UpdateExperienceInfoAsync(UpdateExperienceInformationDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity != null)
            {
                entity.CompanyName = dto.CompanyName;
                entity.City = dto.City;
                entity.CompanyField = dto.CompanyField;

                await _repository.UpdateAsync(entity);
            }
        }

        public async Task DeleteExperienceInfoAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
