namespace DigitalTwin.src.Model.DTOs
{
    public class ResultFuelDTO
    {
        public Guid Id { get; set; }
        public Guid SensorDeviceId { get; set; }
        public double EngineFuel { get; set; }
        public DateTime CreatedAtBySensor { get; set; }
    }

    public class SuccessResultFuelDTO
    {
        public int Status { get; set; } = 200;
        public required ResultFuelDTO Data { get; set; }

        public required string Message { get; set; }
    }

    public class FailedResultFuelDTO
    {
        public required int Status { get; set; }
        public required string Message { get; set; }
    }
}