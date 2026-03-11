using Backend.Database;
using Backend.Models;
using Backend.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Car> CreateCar(Car car, Guid salonId)
        {
            var salonExists = await _context.Salons.FindAsync(salonId);
            if (salonExists==null)
            {
                throw new RepositoryException($"Salon with ID {salonId} not found.");
            }
            car.Salon = salonExists;
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> GetCarById(string carId)
        {
            var car = await _context.Cars.FindAsync(carId);
            if (car == null)
            {
                throw new RepositoryException($"Car with ID {carId} not found.");
            }
            return car;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> EditCar(Car car)
        {
            if(!await _context.Cars.AnyAsync(c => c.ChassisNumber == car.ChassisNumber))
            {
                throw new RepositoryException($"Car with ID {car.ChassisNumber} not found.");
            }
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> DeleteCar(string carId)
        {
            var car = await _context.Cars.FindAsync(carId);
            if (car == null)
            {
                throw new RepositoryException($"Car with ID {carId} not found.");
            }
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<IEnumerable<Car>> ClearCarRepository()
        {
            var cars = await _context.Cars.ToListAsync();
            _context.Cars.RemoveRange(cars);
            await _context.SaveChangesAsync();
            return cars;
        }
    }
}
