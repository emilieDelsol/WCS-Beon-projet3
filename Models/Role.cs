using BeOnAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BeOn.Models
{
    public class Role : IRole
    {
        [Column("id_roles")]
        [Key]
        public String RoleId { get; set; }
        [Column("name")]
        public String Name { get; set; }

        public virtual ICollection<Authorization> Authorizations { get; set; }

        [NotMapped]
        public IEnumerable<IPermission> Permissions 
        {
            get
            {
                return Authorizations.Select(authorization => authorization.Permission);
            }
        }

        public bool IsAllowedTo(string action)
        {
            return Permissions.Any(permission => permission.Name == action);
        }
    }
}
