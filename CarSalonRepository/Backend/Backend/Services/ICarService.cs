using Backend.DTOs;

namespace Backend.Services
{
    public interface ICarService
    {
        Task<CarDTO> CreateCar(CreateCarDTO car, Guid salonId);
        Task<IEnumerable<CarDTO>> GetAllCars();
        Task<CarDTO> GetCarById(string carId);
        Task<CarDTO> EditCar(EditCarDTO car);
        Task<CarDTO> DeleteCar(string carId);
        Task<IEnumerable<CarDTO>> DeleteAllCars();
    }
}
