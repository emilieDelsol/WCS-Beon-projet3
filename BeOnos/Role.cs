using System;
using System.Collections.Generic;
using System.Linq;

namespace BeOnAuth
{
    public class Role : IRole
    {
        public String Name { get; private set; }
        public IEnumerable<Role> Children => _children;
        public IEnumerable<IPermission> Permissions => _permissions;
        private IList<IPermission> _permissions = new List<IPermission> { };
        private IList<Role> _children = new List<Role> { };

        public Role(String name, IEnumerable<Role> children = null) : this(name, null, null)
        {
            if (children != null)
            {
                _children = children.ToList();
            }
        }

        public Role(String name, Role child = null, IPermission permission = null) : this(name)
        {
            if (child != null)
            {
                _children.Add(child);
            }
            if (permission != null)
            {
                _permissions.Add(permission);
            }
        }

        public Role(String name)
        {
            Name = name;
        }

        public Boolean IsAllowedTo(String action)
        {
            if(Permissions.Any(permission => permission.Name == action))
            {
                return true;
            }
            foreach (Role childRole in Children)
            {
                if (childRole.IsAllowedTo(action))
                {
                    return true;
                }
            }
            return false;
        }
    }
}