using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
    public class Authorization
    {
        [Column("id_roles")]
        [ForeignKey("Role")]
        public String RoleId { get; set; }
        public virtual Role Role { get; set; }

        [Column("id_perm")]
        [ForeignKey("Permission")]
        public String PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
