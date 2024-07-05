using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using DigitalTwin.src;
using DigitalTwin.src.Model.DTOs;
using DigitalTwin.src.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace DigitalTwin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogDataController(
        DigitalTwinDBContext context,
        IMapper mapper
    ) : ControllerBase
    {
        private readonly DigitalTwinDBContext _context = context;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public ActionResult<SuccessResultLogDataDTO> Get()
        {
            try {
                var logDatas = _context.LOG_DATA
                    .OrderByDescending(l => l._id)
                    .Take(100)
                    .ToList();

                var resultList = new SuccessResultLogDataDTO {
                    Data = logDatas,
                    Message = "Success Get Data"
                };

                return StatusCode(200, resultList);
            } catch(Exception ex) {
                var failedResult = new FailedResultLogDataDTO
                {
                    Status = 500,
                    Message = ex.Message
                };
                return StatusCode(500, failedResult);
            }
        }
    }
}
