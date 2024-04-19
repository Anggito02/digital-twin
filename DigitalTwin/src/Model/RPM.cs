namespace DigitalTwin.src.Model
{
    public class RPM : BaseModel
    {
        public double EngineRPM { get; set; }
        public DateTime CreatedAtBySensor { get; set; }

        // Foreign Key
        public Guid SensorDeviceId { get; set; }

        public required SensorDevice SensorDevice { get; set; }
    }
}
