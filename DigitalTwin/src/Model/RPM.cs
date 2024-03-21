namespace DigitalTwin.src.Model
{
    public class RPM : BaseModel
    {
        public Guid Id { get; set; }
        public double EngineRPM { get; set; }
        public DateTime CreatedAtBySensor { get; set; }

        // Foreign Key
        public Guid SensorDeviceId { get; set; }

        public SensorDevice SensorDevice { get; set; } = null!;
    }
}
