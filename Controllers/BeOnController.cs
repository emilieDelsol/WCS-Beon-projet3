using BeOn.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Controllers
{
	public class BeOnController : Controller
	{
		private BeOnContext _context;
		public BeOnController(BeOnContext injectedBeonContext)
        {
			_context = injectedBeonContext;
        }
		public IActionResult Index(string IdDevice)
		{
			IEnumerable<Device> devices = new List<Device>();
			Device device = new Device();
			devices = from a in _context.Devices where (a.DeviceId == IdDevice) select a;
			device = devices.First();
			if (device.EnvironmentPayloads.Count == 0)
			{
				return View("Default");
			}
			return View(device);
		}
		public IActionResult Overview()
		{
			IEnumerable<Device> devices =  (from a in _context.Devices where a.EnvironmentPayloads.Count !=0 select a ).ToList() ;  
			return View(devices);
		}
		public IActionResult ListDevices()
		{
			IEnumerable<Device> devices = (from a in _context.Devices select a).ToList();

			return View(devices);
		}
		public IActionResult testDashboard(string IdDevice)
		{
			IEnumerable<Device> devices = new List<Device>();
			Device device = new Device();
			devices = from a in _context.Devices where(a.DeviceId == IdDevice) select a;
			device = devices.First();
			if(device.EnvironmentPayloads.Count == 0)
            {
				return View("Default");
            }
			return View(device);
		}
		public IActionResult Location1Device()
		{
			return View();
		}

	}
}
