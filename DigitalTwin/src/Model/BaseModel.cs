namespace DigitalTwin.src.Model
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ?DeletedAt { get; set; }
    }
}
