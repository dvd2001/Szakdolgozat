using Backend.DTOs;
using Backend.Models;

namespace Backend.Services
{
    public class DTOConversionService : IDTOConversionService
    {
        public SalonDTO ConvertSalonToSalonDTO(Salon salon)
        {
            return new SalonDTO
            {
                SalonId = salon.SalonId,
                Name = salon.Name,
                Address = salon.Address,
                PhoneNumber = salon.PhoneNumber,
                Email = salon.Email,
                Website = salon.Website,
                CarIds = salon.Cars.Select(car => car.ChassisNumber).ToList()
            };
        }

        public CarDTO ConvertCarToCarDTO(Car car)
        {
            return new CarDTO
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
                SalonId = car.Salon.SalonId
            };
        }

        public UserDTO ConvertUserToUserDTO(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username
            };
        }
    }
}
