using AutoMapper;
using WashIt.API.DTOs;
using WashIt.API.Models;

namespace WashIt.API.Profiles
{
    public class DevicesProfile : Profile
    {
        public DevicesProfile()
        {
            CreateMap<Device, DeviceReadDto>();
            CreateMap<DeviceCreateDto, Device>();
        }
    }
}