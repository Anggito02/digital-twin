using AutoMapper;

using DigitalTwin.src.Model;
using DigitalTwin.src.Model.DTOs;

namespace DigitalTwin.src
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InputNewSensorDeviceDTO, SensorDevice>();
            CreateMap<InputUpdateSensorDeviceDTO, SensorDevice>();
            CreateMap<SensorDevice, ResultSensorDeviceDTO>();

            CreateMap<InputNewUserDTO, User>();
            CreateMap<User, ResultUserDTO>();
        }
    }
}
