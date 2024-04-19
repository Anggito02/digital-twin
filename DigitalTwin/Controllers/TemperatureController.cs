using AutoMapper;
using DigitalTwin.src;
using DigitalTwin.src.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalTwin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController(
        DigitalTwinDBContext context,
        IMapper mapper
    ) : ControllerBase
    {
        private readonly DigitalTwinDBContext _context = context;
        private readonly IMapper _mapper = mapper;

        [HttpGet("{sensor_id}")]
        public ActionResult<SuccessResultTemperatureDTO> Get(Guid sensor_id)
        {
            try {
                var temperature = _context.TEMPERATURES.OrderByDescending(r => r.CreatedAtBySensor).FirstOrDefault(r => r.SensorDeviceId == sensor_id);

                var result = new SuccessResultTemperatureDTO
                {
                    Data = _mapper.Map<ResultTemperatureDTO>(temperature),
                    Message = "Success Get Data"
                };
                
                return StatusCode(200, result);
            } catch (Exception ex) {
                var failedResult = new FailedResultTemperatureDTO
                {
                    Status = 500,
                    Message = ex.Message
                };

                return StatusCode(500, failedResult);
            }
        }
    }
}
