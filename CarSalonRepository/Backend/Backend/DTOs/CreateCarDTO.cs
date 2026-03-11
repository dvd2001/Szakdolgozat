namespace Backend.DTOs
{
    public class CreateCarDTO
    {
        public required string ChassisNumber { get; set; } = default!;
        public required string Make { get; set; } = default!;
        public required string Model { get; set; } = default!;
        public required int YearOfManufacture { get; set; }
        public required string EngineType { get; set; } = default!;
        public required double Price { get; set; }
        public required double FuleConsumption { get; set; }
        public required string DriveType { get; set; } = default!;
        public required string GearboxType { get; set; } = default!;
        public required double Weight { get; set; }
        public string ExteriorColor { get; set; } = default!;
        public string InteriorColor { get; set; } = default!;
    }
}
