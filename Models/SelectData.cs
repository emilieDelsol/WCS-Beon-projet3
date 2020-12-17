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
			devices = beOnContext.Devices.Include(a => a.EnvironmentPayloads.Where(e=>e.TimestampEvent<myDate).OrderByDescending(e=>e.TimestampEvent)).Include(e => e.PositionningPayloads.Where(p=>p.TimestampEvent<myDate).OrderByDescending(e=>e.TimestampEvent)).ToList();
			return devices;
		}
		public static IEnumerable<String> SelectDeviceId()
		{
			IEnumerable<String> devicesId = new List<String>();
			BeOnContext beOnContext = new BeOnContext();
			devicesId=(beOnContext.Devices.Select(d=>d.DeviceId));
			return devicesId;
		}
		public static IEnumerable<Device> SelectAllById(string IdDevice, DateTime myDate)
		{
			IEnumerable<Device> devices = new List<Device>();
			BeOnContext beOnContext = new BeOnContext();
			devices = beOnContext.Devices.Include(d => d.EnvironmentPayloads.Where(e => e.DeviceId == IdDevice&&e.TimestampEvent>myDate).OrderBy(e => e.TimestampEvent));
			return devices;

		}
	}
}
