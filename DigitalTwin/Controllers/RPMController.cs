using AutoMapper;
using DigitalTwin.src;
using DigitalTwin.src.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalTwin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RPMController(
        DigitalTwinDBContext context,
        IMapper mapper
    ) : ControllerBase
    {
        private readonly DigitalTwinDBContext _context = context;
        private readonly IMapper _mapper = mapper;

        [HttpGet("{sensor_id}")]
        public ActionResult<SuccessResultRPMDTO> Get(Guid sensor_id)
        {
            try {
                var rpm = _context.RPMS.OrderByDescending(r => r.CreatedAtBySensor).FirstOrDefault(r => r.SensorDeviceId == sensor_id);

                var result = new SuccessResultRPMDTO
                {
                    Data = _mapper.Map<ResultRPMDTO>(rpm),
                    Message = "Success Get Data"
                };

                return StatusCode(200, result);
            } catch (Exception ex) {
                var failedResult = new FailedResultRPMDTO
                {
                    Status = 500,
                    Message = ex.Message
                };

                return StatusCode(500, failedResult);
            }
        }
    }
}
