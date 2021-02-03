using BeOn.Models;
using BeOn.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BeOn.Controllers
{
    public class HomeController : Controller
	{
		private readonly DeviceRepository _deviceRepository;

		public HomeController(DeviceRepository deviceRepository)
        {
			_deviceRepository = deviceRepository;
        }

		public IActionResult Index()
		{
			return View(_deviceRepository.All);
		}

		[HttpGet]
		public IActionResult Details([FromQuery] String deviceId)
		{
			Device device = _deviceRepository.FindById(deviceId);
			ViewResult viewResult = View("Default");
			if (device.EnvironmentPayloads.Count > 0)
            {
				viewResult = View(device);
            }
			return viewResult;
		}
	}
}
