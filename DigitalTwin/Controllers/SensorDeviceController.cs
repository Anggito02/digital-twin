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
    public class SensorDeviceController(
        DigitalTwinDBContext context,
        IMapper mapper
    ) : ControllerBase
    {
        private readonly DigitalTwinDBContext _context = context;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public ActionResult<SuccessResultSensorDeviceDTO> Get()
        {
            try {
                var sensorDevices = _context.SENSOR_DEVICES.Where(sd => sd.IsDeleted == false).ToList();

                var resultList = new List<ResultSensorDeviceDTO>();
                foreach (var e in sensorDevices) {
                    resultList.Add(_mapper.Map<ResultSensorDeviceDTO>(e));
                }

                var successResult = new SuccessResultSensorDeviceDTO
                {
                    Data = resultList,
                    Message = "Success Get Data"
                };
                return StatusCode(200, successResult);
            } catch(Exception ex) {
                var failedResult = new FailedResultSensorDeviceDTO
                {
                    Status = 500,
                    Message = ex.Message
                };
                return StatusCode(500, failedResult);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SuccessResultSensorDeviceDTO> Get(Guid id)
        {
            try {
                var sensorDevice = _context.SENSOR_DEVICES.Find(id) ?? throw new KeyNotFoundException("Data not found");

                if (sensorDevice.IsDeleted == true) {
                    throw new KeyNotFoundException("Data not found");
                }

                var resultList = new List<ResultSensorDeviceDTO>
                {
                    _mapper.Map<ResultSensorDeviceDTO>(sensorDevice)
                };

                var successResult = new SuccessResultSensorDeviceDTO
                {
                    Data = resultList,
                    Message = "Success Get Data"
                };
                return StatusCode(200, successResult);
            } catch(Exception ex) {
                if (ex is KeyNotFoundException) {
                    var failedResult_404 = new FailedResultSensorDeviceDTO
                    {
                        Status = 404,
                        Message = ex.Message
                    };
                    return StatusCode(404, failedResult_404);
                }

                var failedResult_500 = new FailedResultSensorDeviceDTO
                {
                    Status = 500,
                    Message = ex.Message
                };
                return StatusCode(500, failedResult_500);
            }
        }

        [HttpPost]
        public ActionResult<SuccessResultSensorDeviceDTO> Post(InputNewSensorDeviceDTO inputDto)
        {
            try {
                var sensorDevice = _mapper.Map<SensorDevice>(inputDto);

                sensorDevice.Id = Guid.NewGuid();
                sensorDevice.CreatedAt = DateTime.Now;
                sensorDevice.UpdatedAt = DateTime.Now;
                
                _context.SENSOR_DEVICES.Add(sensorDevice);
                _context.SaveChanges();

                return new SuccessResultSensorDeviceDTO
                {
                    Data =
                    [
                        _mapper.Map<ResultSensorDeviceDTO>(sensorDevice)
                    ],
                    Message = "Success Add Data"
                };
            } catch(Exception ex) {
                var failedResult = new FailedResultSensorDeviceDTO
                {
                    Status = 500,
                    Message = ex.Message
                };
                return StatusCode(500, failedResult);
            }
        }

        [HttpPut]
        public ActionResult<SuccessResultSensorDeviceDTO> Put(InputUpdateSensorDeviceDTO inputDto)
        {
            try {
                var sensorDevice = _context.SENSOR_DEVICES.Find(inputDto.Id) ?? throw new KeyNotFoundException("Data not found");

                if (sensorDevice.IsDeleted == true) {
                    throw new KeyNotFoundException("Data not found");
                }

                _mapper.Map(inputDto, sensorDevice);
                sensorDevice.UpdatedAt = DateTime.Now;

                _context.SENSOR_DEVICES.Update(sensorDevice);
                _context.SaveChanges();

                return new SuccessResultSensorDeviceDTO
                {
                    Data =
                    [
                        _mapper.Map<ResultSensorDeviceDTO>(sensorDevice)
                    ],
                    Message = "Success Update Data"
                };
            } catch(Exception ex) {
                if (ex is KeyNotFoundException) {
                    var failedResult_404 = new FailedResultSensorDeviceDTO
                    {
                        Status = 404,
                        Message = ex.Message
                    };
                    return StatusCode(404, failedResult_404);
                }

                var failedResult_500 = new FailedResultSensorDeviceDTO
                {
                    Status = 500,
                    Message = ex.Message
                };
                return StatusCode(500, failedResult_500);
            }
        }

        [HttpDelete]
        public ActionResult<SuccessResultSensorDeviceDTO> Delete(Guid id)
        {
            try {
                var sensorDevice = _context.SENSOR_DEVICES.Find(id) ?? throw new KeyNotFoundException("Data not found");

                if (sensorDevice.IsDeleted == true) {
                    throw new KeyNotFoundException("Data not found");
                }

                sensorDevice.IsDeleted = true;
                sensorDevice.DeletedAt = DateTime.Now;

                _context.SENSOR_DEVICES.Update(sensorDevice);
                _context.SaveChanges();

                return new SuccessResultSensorDeviceDTO
                {
                    Data =
                    [
                        _mapper.Map<ResultSensorDeviceDTO>(sensorDevice)
                    ],
                    Message = "Success Delete Data"
                };
            } catch(Exception ex) {
                if (ex is KeyNotFoundException) {
                    var failedResult_404 = new FailedResultSensorDeviceDTO
                    {
                        Status = 404,
                        Message = ex.Message
                    };
                    return StatusCode(404, failedResult_404);
                }

                var failedResult_500 = new FailedResultSensorDeviceDTO
                {
                    Status = 500,
                    Message = ex.Message
                };
                return StatusCode(500, failedResult_500);
            }
        }
    }
}
