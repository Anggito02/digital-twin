namespace DigitalTwin.src.Model
{
    public class SensorDevice : BaseModel
    {
        public required string Name { get; set; }
        public required string Model { get; set; }
        public double OperatingVoltage { get; set; }
        public double OperatingCurrent { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool IsConnected { get; set; } = false;
    }
}
