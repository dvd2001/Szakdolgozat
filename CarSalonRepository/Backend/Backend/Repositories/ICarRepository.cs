using Backend.Models;

namespace Backend.Repositories
{
    public interface ICarRepository
    {
        Task<Car> CreateCar(Car car, Guid salonId);
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetCarById(string carId);
        Task<Car> EditCar(Car car);
        Task<Car> DeleteCar(string carId);
        Task<IEnumerable<Car>> ClearCarRepository();
    }
}
