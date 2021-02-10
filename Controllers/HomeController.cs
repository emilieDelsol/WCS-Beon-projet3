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
			return View();
		}
		public IActionResult List()
		{
			return View(_deviceRepository.All);
		}
		public IActionResult Map()
		{
			return View();
		}

		[HttpGet("[action]/{deviceId}")]
		public IActionResult Details([FromRoute] String deviceId)
		{
			Device device = _deviceRepository.FindById(deviceId);
			return View(device);
		}
	}
}
