namespace DigitalTwin.src.Model
{
    public class Temperature : BaseModel
    {
        public double EngineTemperature { get; set; }
        public DateTime CreatedAtBySensor { get; set; }

        // Foreign Key
        public Guid SensorDeviceId { get; set; }

        public required SensorDevice SensorDevice { get; set; }
    }
}
