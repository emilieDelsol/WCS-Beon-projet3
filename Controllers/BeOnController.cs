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
				IEnumerable<Device> devices = new List<Device>();
				devices = SelectData.SelectDeviceWithoutList();
				return View(devices);
		}
		public IActionResult testDashboard(string IdDevice)
		{
			List<Device> devices = new List<Device>();
			
			DateTime myDate = DateTime.Now;

			devices = SelectData.SelectAllDevice(myDate).Where(a => a.DeviceId == IdDevice).ToList();
			devices.ToList().ForEach(d => d.EnvironmentPayloads.OrderByDescending(e => e.TimestampEvent));
			devices.ToList().ForEach(d => d.PositionningPayloads.OrderByDescending(pos => pos.TimestampEvent));
			Device device = devices.First();
			return View(device);
		}

	}
}
