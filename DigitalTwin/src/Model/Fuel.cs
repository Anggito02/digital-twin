namespace DigitalTwin.src.Model
{
    public class Fuel : BaseModel
    {
        public double EngineFuel { get; set; }
        public DateTime CreatedAtBySensor { get; set; }

        // Foreign Key
        public Guid SensorDeviceId { get; set; }

        public required SensorDevice SensorDevice { get; set; }
    }
}
