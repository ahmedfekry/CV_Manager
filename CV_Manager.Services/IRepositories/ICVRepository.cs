using CV_Manager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Manager.Services.IRepositories
{
    public interface ICVRepository
    {
        Task<CV?> GetByIdAsync(int id);
        Task<IEnumerable<CV>> GetAllAsync();
        Task AddAsync(CV entity);
        Task UpdateAsync(CV entity);
        Task DeleteAsync(int id);
    }
}
