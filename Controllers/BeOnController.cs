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
			return View();
		}
		public IActionResult testDashboard()
		{
			return View();
		}

	}
}
