using CV_Manager.Domain;
using CV_Manager.Services.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CV_Manager.Infrastructure.Repositories
{
    public class CVRepository : ICVRepository
    {
        private readonly ApplicationDbContext ApplicationDbContext;

        public CVRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public async Task AddAsync(CV cv)
        {
            await ApplicationDbContext.AddAsync(cv);
            await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cv = await ApplicationDbContext.CVs.FindAsync(id);
            if (cv != null)
            {
                ApplicationDbContext.Remove(cv);
                await ApplicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CV>> GetAllAsync()
        {
            return await ApplicationDbContext.CVs
                         .Include(e => e.PersonalInformation)
                         .Include(e => e.ExperienceInformation)
                         .ToListAsync();
        }

        public async Task<CV> GetByIdAsync(int id)
        {
            return await ApplicationDbContext.CVs.Include(e => e.PersonalInformation)
                .Include(e => e.ExperienceInformation)
                .FirstOrDefaultAsync(e => e.Id == id);

        }

        public async Task UpdateAsync(CV cv)
        {
            ApplicationDbContext.Update(cv);
            await ApplicationDbContext.SaveChangesAsync();
        }
    }
}
