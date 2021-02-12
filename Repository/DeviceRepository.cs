using BeOn.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeOn.Repository
{
    public class DeviceRepository : IRepository<Device>
    {
        private readonly BeOnContext _context;

        public DeviceRepository(BeOnContext context)
        {
            _context = context;
        }

        public virtual IQueryable<Device> All => _context.Devices;
        public virtual IQueryable<Device> AllDevices()
        {
            IQueryable<Device> devices = _context.Devices;
            return devices;
        }

        public Device Find(Device device)
        {
            return _context.Devices.Single(d => d.DeviceId == device.DeviceId);
        }

        public Device FindById(String deviceId)
        {
            return _context.Devices.Single(device => device.DeviceId == deviceId);
        }

		public static implicit operator List<object>(DeviceRepository v)
		{
			throw new NotImplementedException();
		}
	}
}
