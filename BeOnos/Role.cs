using System;
using System.Collections.Generic;
using System.Linq;

namespace BeOnos
{
    public class Role
    {
        public string Name { get; set; }
        public IList<Permission> Permissions { get; set; }
        public bool ContainsPermission(String permissionName)
        {
            return Permissions.Any(permission => permission.Name == permissionName);
        }
    }
}