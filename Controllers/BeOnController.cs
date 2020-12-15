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

		public IActionResult ListDevices()
		{
			DateTime mydate = DateTime.Now.AddDays(-30);
			List<EnvironmentPayload> environmentPayloads = SelectData.SelectEnvironmentPayloads().Where(e=>e.TimestampEvent<mydate).ToList();
			
			return View(environmentPayloads);
		}
		public IActionResult testDashboard(int SeqNumber)
		{
			
			List<EnvironmentPayload> environmentPayloads = SelectData.SelectEnvironmentPayloads().Where(e=>e.SeqNumber==SeqNumber).ToList();
			return View(environmentPayloads);
		}

	}
}
