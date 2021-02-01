using BeOn.Models;
using BeOnos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeOn.Controllers
{
	public class BeOnController : Controller
	{
		private readonly BeOnContext _context;
		public BeOnController(BeOnContext injectedBeonContext)
        {
			_context = injectedBeonContext;
        }
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Overview()
		{
			IEnumerable<Device> devices =  (from a in _context.Devices select a ).ToList(); //need add toList() -> conflict with List Devices --->NpgsqlOperationInProgressException: A command is already in progress
			return View(devices);
		}
		public IActionResult ListDevices()
		{
			IEnumerable<Device> devices = (from a in _context.Devices select a).ToList(); //need add toList() -> conflict with overview --->  NpgsqlOperationInProgressException: A command is already in progress

			return View(devices);
		}
		public IActionResult Dashboard(string IdDevice)
		{
			
			IQueryable<Device> devices = from a in _context.Devices where(a.DeviceId == IdDevice) select a;
			Device device = devices.First();
			if(device.EnvironmentPayloads.Count == 0)
            {
				return View("Default");
            }
			return View(device);
		}
		public IActionResult Location1Device(string IdDevice)
		{
			IQueryable<Device> devices = from a in _context.Devices where (a.DeviceId == IdDevice) select a;
			Device device = devices.First();
			return View(device);
		}	
		
		public IActionResult Temp(string IdDevice)
		{
			IQueryable<Device> devices = from a in _context.Devices where (a.DeviceId == IdDevice) select a;
			Device device = devices.First();
			return View(device);
		}

		public void CheckUser(string Identifier, string Password)
        {
			User userContext = _context.Users.Where(a => a.Name == Identifier).First();
			if (userContext != null)
            {
				//cherche le pass hashé en base
				string passwordHash = userContext.PasswordHash;	
				UserBeOnos userBeOnos = new UserBeOnos() { Identifier = Identifier, Password = passwordHash };
				bool passwordIsValid = userBeOnos.CheckPassword(Password);
				if (passwordIsValid)
                {
					Console.WriteLine("Identifier : " + Identifier + "\nPassword is OK");
                }
                else 
				{
					Console.WriteLine("Identifier : " + Identifier + "\nWrong Password");
				}

            }
            else 
			{
				Console.WriteLine("Wrong Identifier");           
			}
		

        }

	}
}
