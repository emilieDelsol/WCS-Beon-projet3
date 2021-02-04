using BeOn.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BeOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceRepository _deviceRepository;

        public DeviceController(DeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        [HttpGet]
        public IActionResult GetAllDevices()
        {
            return Ok(_deviceRepository.All);
        }
    }
}

