namespace DigitalTwin.src.Model
{
    public class LogData
    {
        public int _id { get; set; }
        public DateTime _dbTime { get; set; }
        public string _terminalTime { get; set; } = string.Empty;
        public string _groupName { get; set; } = string.Empty;
        public string temperature { get; set; } = string.Empty;
        public string fuel { get; set; } = string.Empty;
        public string rpm { get; set; } = string.Empty;
        public string power { get; set; } = string.Empty;
    }
}