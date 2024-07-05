namespace DigitalTwin.src.Model.DTOs
{
    public class InputNewUserDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Username { get; set; }
    }

    public class ResultUserDTO
    {
        public required Guid Id { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
    }

    public class SuccessResultUserDTO
    {
        public int Status { get; set; } = 200;
        public required ResultUserDTO Data { get; set; }

        public required string Message { get; set; }
    }

    public class FailedResultUserDTO
    {
        public required int Status { get; set; }
        public required string Message { get; set; }
    }
}