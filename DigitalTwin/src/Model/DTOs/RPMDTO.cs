namespace DigitalTwin.src.Model.DTOs
{
    public class ResultRPMDTO
    {
        public Guid Id { get; set; }
        public Guid SensorDeviceId { get; set; }
        public double EngineRPM { get; set; }
        public DateTime CreatedAtBySensor { get; set; }
    }

    public class SuccessResultRPMDTO
    {
        public int Status { get; set; } = 200;
        public required ResultRPMDTO Data { get; set; }

        public required string Message { get; set; }
    }

    public class FailedResultRPMDTO
    {
        public required int Status { get; set; }
        public required string Message { get; set; }
    }
}