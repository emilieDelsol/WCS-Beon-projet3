using BeOn.Filters;
using BeOn.Models;
using System;
using System.Linq;

namespace BeOn.Repository
{
    public class EnvironmentRepository : IRepository<DeviceEnvironment>
    {
        private readonly BeOnContext _context;

        public EnvironmentRepository(BeOnContext context)
        {
            _context = context;
        }

        public IQueryable<DeviceEnvironment> All => _context.Environments;

        public DeviceEnvironment Find(DeviceEnvironment entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DeviceEnvironment> FindAllByDevice(Device device)
        {
            return All.Where(environment => environment.DeviceId == device.DeviceId);
        }
    }
}
