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
				BeOnContext beOnContext = new BeOnContext();
				devices = SelectData.SelectAllDevice();
				return View(devices);
		}
		public IActionResult testDashboard(string IdDevice)
		{
			IEnumerable<Device> devices = new List<Device>();
			BeOnContext beOnContext = new BeOnContext();
			devices = SelectData.SelectAllDevice().Where(a => a.DeviceId == IdDevice);
			Device devic = devices.First();
			devic.PositionningPayloads = devic.PositionningPayloads.OrderByDescending(p => p.TimestampEvent).ToList();
			devic.EnvironmentPayloads = devic.EnvironmentPayloads.OrderByDescending(e => e.TimestampEvent).ToList();

			return View(devic);
		}

	}
}
