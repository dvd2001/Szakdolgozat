using Backend.Database;
using Backend.Models;
using Backend.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class SalonRepository : ISalonRepository
    {
        private readonly ApplicationDbContext _context;

        public SalonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Salon> CreateSalon(Salon salon)
        {
            await _context.Salons.AddAsync(salon);
            await _context.SaveChangesAsync();
            return salon;
        }

        public async Task<IEnumerable<Salon>> GetAllSalons()
        {
            return await _context.Salons.ToListAsync();
        }

        public async Task<Salon> GetSalonById(Guid salonId)
        {
            var salon = await _context.Salons.Include(s => s.Cars).FirstOrDefaultAsync(s => s.SalonId == salonId);
            if (salon == null)
            {
                throw new RepositoryException($"Salon with ID {salonId} not found.");
            }
            return salon;
        }

        public async Task<Salon> EditSalon(Salon salon)
        {
            if(!await _context.Salons.AnyAsync(s => s.SalonId == salon.SalonId))
            {
                throw new RepositoryException($"Salon with ID {salon.SalonId} not found.");
            }
            _context.Salons.Update(salon);
            await _context.SaveChangesAsync();
            return salon;
        }

        public async Task<Salon> DeleteSalon(Guid salonId)
        {
            var salon = await _context.Salons.FindAsync(salonId);
            if (salon == null)
            {
                throw new RepositoryException($"Salon with ID {salonId} not found.");
            }
            _context.Salons.Remove(salon);
            await _context.SaveChangesAsync();
            return salon;
        }

        public async Task<IEnumerable<Salon>> ClearSalonRepository()
        {
            var salons = await _context.Salons.ToListAsync();
            _context.Salons.RemoveRange(salons);
            await _context.SaveChangesAsync();
            return salons;
        }
    }
}
