namespace DigitalTwin.src.Model
{
    public class SensorDevice : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public double OperatingVoltage { get; set; }
        public double OperatingCurrent { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public ICollection<Temperature> Temperatures { get; set; } = null!;
        public ICollection<Fuel> Fuels { get; set; } = null!;
        public ICollection<RPM> RPMs { get; set; } = null!;
    }
}
