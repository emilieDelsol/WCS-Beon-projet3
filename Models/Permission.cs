using BeOnAuth;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeOn.Models
{
    public class Permission : IPermission
    {
        [Column("permission_id")]
        [Key]
        public String PermissionId { get; set; }

        [Column("description")]
        public String Name { get; set; }
    }
}
