using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WashIt.API.DTOs;
using WashIt.API.Service;

namespace WashIt.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService deviceService;
        private readonly IMapper mapper;

        public DevicesController(IDeviceService deviceService, IMapper mapper)
        {
            this.deviceService = deviceService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceReadDto>>> GetDevices()
        {
            Console.WriteLine("Getting Devices...");

            var deviceItems = await deviceService.GetAllDevicesAsync();

            return Ok(mapper.Map<IEnumerable<DeviceReadDto>>(deviceItems));
        }


    }
}