using Backend.Repositories;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Services
{
    public class CarService(ICarRepository carRepository, IDTOConversionService dtoConversionService) : ICarService
    {
        public async Task<CarDTO> CreateCar(CreateCarDTO car, Guid salonId)
        {
            var newCar = new Car
            {
                ChassisNumber = car.ChassisNumber,
                Make = car.Make,
                Model = car.Model,
                YearOfManufacture = car.YearOfManufacture,
                EngineType = car.EngineType,
                Price = car.Price,
                FuleConsumption = car.FuleConsumption,
                DriveType = car.DriveType,
                GearboxType = car.GearboxType,
                Weight = car.Weight,
                ExteriorColor = car.ExteriorColor,
                InteriorColor = car.InteriorColor
            };
            var createdCar = await carRepository.CreateCar(newCar, salonId);
            var createdCarDTO = dtoConversionService.ConvertCarToCarDTO(createdCar);
            return createdCarDTO;
        }

        public async Task<CarDTO> GetCarById(string chassisNumber)
        {
            var result = await carRepository.GetCarById(chassisNumber);
            var carDTO = dtoConversionService.ConvertCarToCarDTO(result);
            return carDTO;
        }

        public async Task<IEnumerable<CarDTO>> GetAllCars()
        {
            var result = await carRepository.GetAllCars();
            var carDTOs = result.Select(car => dtoConversionService.ConvertCarToCarDTO(car)).ToList();
            return carDTOs;
        }

        public async Task<CarDTO> EditCar(EditCarDTO car)
        {
            var editedCar = new Car
            {
                ChassisNumber = car.ChassisNumber,
                Make = car.Make,
                Model = car.Model,
                YearOfManufacture = car.YearOfManufacture,
                EngineType = car.EngineType,
                Price = car.Price,
                FuleConsumption = car.FuleConsumption,
                DriveType = car.DriveType,
                GearboxType = car.GearboxType,
                Weight = car.Weight,
                ExteriorColor = car.ExteriorColor,
                InteriorColor = car.InteriorColor,
                Salon = new Salon
                {
                    SalonId = car.Salon.SalonId,
                    Name = car.Salon.Name,
                    Address = car.Salon.Address,
                    PhoneNumber = car.Salon.PhoneNumber,
                    Email = car.Salon.Email,
                    Website = car.Salon.Website
                }
            };
            var result = await carRepository.EditCar(editedCar);
            var editedCarDTO = dtoConversionService.ConvertCarToCarDTO(result);
            return editedCarDTO;
        }

        public async Task<CarDTO> DeleteCar(string chassisNumber)
        {
            var result = await carRepository.DeleteCar(chassisNumber);
            var deletedCarDTO = dtoConversionService.ConvertCarToCarDTO(result);
            return deletedCarDTO;
        }

        public async Task<IEnumerable<CarDTO>> DeleteAllCars()
        {
            var result = await carRepository.ClearCarRepository();
            var deletedCarDTOs = result.Select(car => dtoConversionService.ConvertCarToCarDTO(car)).ToList();
            return deletedCarDTOs;
        }
    }
}
