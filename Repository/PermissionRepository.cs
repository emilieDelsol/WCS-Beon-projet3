using BeOnAuth;
using System.Linq;

namespace BeOn.Repository
{
    public class PermissionRepository : IRepository<Permission>
    {
        public IQueryable<Permission> All => throw new System.NotImplementedException();

        public Permission Find(Permission permission)
        {
            throw new System.NotImplementedException();
        }
    }
}
