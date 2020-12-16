using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
	public class SelectData
	{
		public static List<EnvironmentPayload> SelectEnvironmentPayloads()
		{
			List<EnvironmentPayload> environmentPayloads = new List<EnvironmentPayload>();
			List<Device> devices = new List<Device>();

			BeOnContext beOnContext = new BeOnContext();
			foreach(EnvironmentPayload environment in beOnContext.EnvironmentPayloads)
			{
				environmentPayloads.Add(environment);
			}
			List<EnvironmentPayload>  environmentPayloadsTest =  environmentPayloads.OrderByDescending(environmentPayloads => environmentPayloads.TimestampEvent).ToList();
			return environmentPayloadsTest;
		}
		public static IEnumerable<Device> SelectAllDevice(DateTime myDate)
		{			
			IEnumerable<Device> devices = new List<Device>();

			BeOnContext beOnContext = new BeOnContext();
			devices = beOnContext.Devices.Include(a => a.EnvironmentPayloads.Where(e=>e.TimestampEvent<myDate)).Include(e => e.PositionningPayloads.Where(p=>p.TimestampEvent>myDate)).ToList();
			return devices;
		}
		public static IEnumerable<Device> SelectDeviceWithoutList()
		{
			IEnumerable<Device> devices = new List<Device>();
			BeOnContext beOnContext = new BeOnContext();
			devices = beOnContext.Devices;
			return devices;
		}
	}
}
