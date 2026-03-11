using Backend.Models;

namespace Backend.Repositories
{
    public interface ISalonRepository
    {
        Task<Salon> CreateSalon(Salon salon);
        Task<IEnumerable<Salon>> GetAllSalons();
        Task<Salon> GetSalonById(Guid salonId);
        Task<Salon> EditSalon(Salon salon);
        Task<Salon> DeleteSalon(Guid salonId);
        Task<IEnumerable<Salon>> ClearSalonRepository();
    }
}
