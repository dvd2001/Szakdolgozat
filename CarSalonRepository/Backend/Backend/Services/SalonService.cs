using Backend.Repositories;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Services
{
    public class SalonService(ISalonRepository salonRepository, IDTOConversionService dtoConversionService) : ISalonService
    {
        public async Task<SalonDTO> CreateSalon(CreateSalonDTO salonDTO)
        {
            var newSalon = new Salon
            {
                SalonId = Guid.NewGuid(),
                Name = salonDTO.Name,
                Address = salonDTO.Address,
                PhoneNumber = salonDTO.PhoneNumber,
                Email = salonDTO.Email,
                Website = salonDTO.Website,
                Cars = salonDTO.Cars.Select(carDTO => new Car
                {
                    ChassisNumber = carDTO.ChassisNumber,
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    YearOfManufacture = carDTO.YearOfManufacture,
                    EngineType = carDTO.EngineType,
                    Price = carDTO.Price,
                    FuleConsumption = carDTO.FuleConsumption,
                    DriveType = carDTO.DriveType,
                    GearboxType = carDTO.GearboxType,
                    Weight = carDTO.Weight,
                    ExteriorColor = carDTO.ExteriorColor,
                    InteriorColor = carDTO.InteriorColor
                }).ToList() ?? new List<Car>()
            };

            var createdSalon = await salonRepository.CreateSalon(newSalon);
            var createdsalonDTO = dtoConversionService.ConvertSalonToSalonDTO(createdSalon);

            return createdsalonDTO;
        }

        public async Task<SalonDTO> GetSalonById(Guid salonId)
        {
            var result = await salonRepository.GetSalonById(salonId);
            var salonDTO = dtoConversionService.ConvertSalonToSalonDTO(result);
            return salonDTO;
        }

        public async Task<IEnumerable<SalonDTO>> GetAllSalons()
        {
            var result = await salonRepository.GetAllSalons();
            var salonDTOs = result.Select(salon => dtoConversionService.ConvertSalonToSalonDTO(salon)).ToList();
            return salonDTOs;
        }

        public async Task<SalonDTO> EditSalon(EditSalonDTO salonDTO)
        {
            var editedSalon = new Salon
            {
                SalonId = salonDTO.SalonId,
                Name = salonDTO.Name,
                Address = salonDTO.Address,
                PhoneNumber = salonDTO.PhoneNumber,
                Email = salonDTO.Email,
                Website = salonDTO.Website,
                Cars = salonDTO.Cars.Select(carDTO => new Car
                {
                    ChassisNumber = carDTO.ChassisNumber,
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    YearOfManufacture = carDTO.YearOfManufacture,
                    EngineType = carDTO.EngineType,
                    Price = carDTO.Price,
                    FuleConsumption = carDTO.FuleConsumption,
                    DriveType = carDTO.DriveType,
                    GearboxType = carDTO.GearboxType,
                    Weight = carDTO.Weight,
                    ExteriorColor = carDTO.ExteriorColor,
                    InteriorColor = carDTO.InteriorColor
                }).ToList() ?? new List<Car>()
            };
            var result = await salonRepository.EditSalon(editedSalon);
            var editedSalonDTO = dtoConversionService.ConvertSalonToSalonDTO(result);
            return editedSalonDTO;
        }

        public async Task<SalonDTO> DeleteSalon(Guid salonId)
        {
            var result = await salonRepository.DeleteSalon(salonId);
            var deletedSalonDTO = dtoConversionService.ConvertSalonToSalonDTO(result);
            return deletedSalonDTO;
        }

        public async Task<IEnumerable<SalonDTO>> DeleteAllSalons()
        {
            var result = await salonRepository.ClearSalonRepository();
            var deletedSalonDTOs = result.Select(salon => dtoConversionService.ConvertSalonToSalonDTO(salon)).ToList();
            return deletedSalonDTOs;
        }

    }
}
