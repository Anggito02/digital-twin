namespace DigitalTwin.src.Model
{
    public class User : BaseModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Username { get; set; }
    }
}
