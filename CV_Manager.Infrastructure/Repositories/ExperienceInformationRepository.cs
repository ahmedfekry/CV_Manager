using CV_Manager.Domain;
using CV_Manager.Services.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CV_Manager.Infrastructure.Repositories
{
    public class ExperienceInformationRepository : IExperienceInformationRepository
    {
        private readonly ApplicationDbContext _context;

        public ExperienceInformationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExperienceInformation?> GetByIdAsync(int id)
        {
            return await _context.ExperienceInformations.FindAsync(id);
        }

        public async Task<IEnumerable<ExperienceInformation>> GetAllAsync()
        {
            return await _context.ExperienceInformations.ToListAsync();
        }

        public async Task AddAsync(ExperienceInformation entity)
        {
            await _context.ExperienceInformations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ExperienceInformation entity)
        {
            _context.ExperienceInformations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ExperienceInformations.FindAsync(id);
            if (entity != null)
            {
                _context.ExperienceInformations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
