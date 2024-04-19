namespace DigitalTwin.src.Model.DTOs
{
    public class ResultTemperatureDTO
    {
        public Guid Id { get; set; }
        public Guid SensorDeviceId { get; set; }
        public double EngineTemperature { get; set; }
        public DateTime CreatedAtBySensor { get; set; }
    }

    public class SuccessResultTemperatureDTO
    {
        public int Status { get; set; } = 200;
        public required ResultTemperatureDTO Data { get; set; }

        public required string Message { get; set; }
    }

    public class FailedResultTemperatureDTO
    {
        public required int Status { get; set; }
        public required string Message { get; set; }
    }
}