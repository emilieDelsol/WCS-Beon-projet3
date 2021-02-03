using System;
using System.Collections.Generic;
using System.Text;

namespace BeOnAuth
{
    public interface IRole
    {
        String Name { get; }
        IEnumerable<IPermission> Permissions { get; }

        Boolean IsAllowedTo(String action);
    }
}
