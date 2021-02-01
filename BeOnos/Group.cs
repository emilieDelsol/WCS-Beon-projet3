using System;
using System.Collections.Generic;

namespace BeOnos
{
    public class Group
    {
        public IList<Role> Roles { get; set; }

        public bool IsAllowedTo(String permissionName)
        {
            Boolean permissionContained = false;
            foreach (Role role in Roles)
            {
                permissionContained = role.ContainsPermission(permissionName);
                if (permissionContained)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
