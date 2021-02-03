using System;

namespace BeOnAuth
{
    public class Group
    {
        public Role Role { get; set; }

        public bool IsAllowedTo(IPermission permission)
        {
            throw new NotImplementedException();
        }
    }
}
