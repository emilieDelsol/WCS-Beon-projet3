using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
	public class SelectData
	{
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
