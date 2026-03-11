using Backend.DTOs;
using Backend.Models;

namespace Backend.Services
{
    public interface IDTOConversionService
    {
        public SalonDTO ConvertSalonToSalonDTO(Salon salon);
        public CarDTO ConvertCarToCarDTO(Car car);
        public UserDTO ConvertUserToUserDTO(User user);
    }
}
