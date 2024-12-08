using CV_Manager.Domain;
using CV_Manager.Services.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CV_Manager.Infrastructure.Repositories
{
    public class PersonalInformationRepository : IPersonalInformationRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonalInformationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PersonalInformation?> GetByIdAsync(int id)
        {
            return await _context.PersonalInformations.FindAsync(id);
        }

        public async Task<IEnumerable<PersonalInformation>> GetAllAsync()
        {
            return await _context.PersonalInformations.ToListAsync();
        }

        public async Task AddAsync(PersonalInformation entity)
        {
            await _context.PersonalInformations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PersonalInformation entity)
        {
            _context.PersonalInformations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.PersonalInformations.FindAsync(id);
            if (entity != null)
            {
                _context.PersonalInformations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
