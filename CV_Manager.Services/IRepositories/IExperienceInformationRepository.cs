using CV_Manager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Services.IRepositories
{
    public interface IExperienceInformationRepository
    {
        Task<ExperienceInformation?> GetByIdAsync(int id);
        Task<IEnumerable<ExperienceInformation>> GetAllAsync();
        Task AddAsync(ExperienceInformation entity);
        Task UpdateAsync(ExperienceInformation entity);
        Task DeleteAsync(int id);
    }
}
