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
			DateTime mydate = DateTime.Now.AddDays(-200);
			List<EnvironmentPayload> environmentPayloads = SelectData.SelectEnvironmentPayloads().Where(e => e.TimestampEvent > mydate).OrderBy(e=>e.IdDevice).ToList();
		
			List<EnvironmentPayload> deviceList = new List<EnvironmentPayload>();
			String flag = "";
			foreach(EnvironmentPayload environment in environmentPayloads)
			{
				if (environment.IdDevice!=flag)
				{
					deviceList.Add(environment);
				}
				flag = environment.IdDevice;
			}
			return View(deviceList);
		}
		public IActionResult testDashboard(string IdDevice)
		{
			
			List<EnvironmentPayload> environmentPayloads = SelectData.SelectEnvironmentPayloads().Where(e=>e.IdDevice==IdDevice).ToList();
			return View(environmentPayloads);
		}

	}
}
