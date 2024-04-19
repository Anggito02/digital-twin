namespace DigitalTwin.src.Model.DTOs
{
    public class InputNewSensorDeviceDTO
    {
        public required string Name { get; set; }
        public required string Model { get; set; }
        public double OperatingVoltage { get; set; }
        public double OperatingCurrent { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class InputUpdateSensorDeviceDTO : InputNewSensorDeviceDTO
    {
        public Guid Id { get; set; }
    }

    public class ResultSensorDeviceDTO
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public required string Name { get; set; }
        public required string Model { get; set; }
        public double OperatingVoltage { get; set; }
        public double OperatingCurrent { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class SuccessResultSensorDeviceDTO
    {
        public int Status { get; set; } = 200;
        public required List<ResultSensorDeviceDTO> Data { get; set; }

        public required string Message { get; set; }
    }

    public class FailedResultSensorDeviceDTO
    {
        public required int Status { get; set; }
        public required string Message { get; set; }
    }
}