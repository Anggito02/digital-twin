using AutoMapper;
using DigitalTwin.src;
using DigitalTwin.src.Model;
using DigitalTwin.src.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalTwin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(
        DigitalTwinDBContext context,
        IMapper mapper
    ) : ControllerBase
    {
        private readonly DigitalTwinDBContext _context = context;
        private readonly IMapper _mapper = mapper;

        [HttpPost("/api/users/")]
        public ActionResult<SuccessResultUserDTO> Post(Guid id)
        {
            try {
                var user = _context.USERS.Find(id) ?? throw new KeyNotFoundException("User not found");

                var result = new SuccessResultUserDTO
                {
                    Data = _mapper.Map<ResultUserDTO>(user),
                    Message = "Success Get Data"
                };

                return StatusCode(200, result);
            } catch (Exception ex) {
                var failedResult = new FailedResultUserDTO
                {
                    Status = 500,
                    Message = ex.Message
                };

                return StatusCode(500, failedResult);
            }
        }

        [HttpPost("/api/users/create")]
        public ActionResult<SuccessResultUserDTO> Post(InputNewUserDTO inputDto)
        {
            try {
                // validate user data
                if (inputDto.Username == null) throw new ArgumentNullException("Username cannot be null");

                if (inputDto.Password == null) throw new ArgumentNullException("Password cannot be null");

                if (inputDto.Email == null) throw new ArgumentNullException("Email cannot be null");

                // validate password
                if (inputDto.Password.Length < 8) throw new ArgumentException("Password must be at least 8 characters long");

                // validate email
                if (!inputDto.Email.Contains('@')) throw new ArgumentException("Email must contain @");

                // validate username
                if (inputDto.Username.Length < 3 || inputDto.Username.Length > 20) throw new ArgumentException("Username must be at least 3 characters long and at most 20 characters long");

                var user = _mapper.Map<User>(inputDto);
                user.Id = Guid.NewGuid();
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;

                _context.USERS.Add(user);
                _context.SaveChanges();

                var result = new SuccessResultUserDTO
                {
                    Data = _mapper.Map<ResultUserDTO>(user),
                    Message = "Success Add Data"
                };

                return StatusCode(200, result);
                
            } catch(Exception ex) {
                var failedResult = new FailedResultUserDTO
                {
                    Status = 500,
                    Message = ex.Message
                };
                return StatusCode(500, failedResult);
            }
        }       
    }
}
