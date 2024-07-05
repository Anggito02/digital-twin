namespace DigitalTwin.src.Model.DTOs
{
    public class SuccessResultLogDataDTO
    {
        public int Status { get; set; } = 200;
        public required List<LogData> Data { get; set; }

        public required string Message { get; set; }
    }

    public class FailedResultLogDataDTO
    {
        public required int Status { get; set; }
        public required string Message { get; set; }
    }
}