using BeOn.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Controllers
{
	public class BeOnController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Overview()
		{
			return View();
		}
		public IActionResult ListDevices()
		{
				IEnumerable<String> devices = new List<String>();
			DateTime myDate = DateTime.Now.AddDays(-90);
			devices = SelectData.SelectDeviceId();
			return View(devices);
		}
		public IActionResult testDashboard(string IdDevice)
		{
			List<Device> devices = new List<Device>();
			
			DateTime myDate = DateTime.Now.AddDays(-90);

			devices = SelectData.SelectAllById(IdDevice,myDate).ToList();
			Device device = devices.First();
			return View(device);
		}

	}
}
