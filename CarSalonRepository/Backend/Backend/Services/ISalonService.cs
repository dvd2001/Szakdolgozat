using Backend.DTOs;

namespace Backend.Services
{
    public interface ISalonService
    {
        Task<SalonDTO> CreateSalon(CreateSalonDTO salon);
        Task<IEnumerable<SalonDTO>> GetAllSalons();
        Task<SalonDTO> GetSalonById(Guid salonId);
        Task<SalonDTO> EditSalon(EditSalonDTO salon);
        Task<SalonDTO> DeleteSalon(Guid salonId);
        Task<IEnumerable<SalonDTO>> DeleteAllSalons();
    }
}
