using CV_Manager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Services.IRepositories
{
    public interface IPersonalInformationRepository
    {
        Task<PersonalInformation?> GetByIdAsync(int id);
        Task<IEnumerable<PersonalInformation>> GetAllAsync();
        Task AddAsync(PersonalInformation entity);
        Task UpdateAsync(PersonalInformation entity);
        Task DeleteAsync(int id);
    }
}
