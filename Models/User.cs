using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
    [Table("users")]
    public class User
    {
        [Column("id_users")]
        public virtual int UserId { get; set; }

        [Column("username")]
        public virtual string Name { get; set; }

        [Column("password")]
        public virtual string PasswordHash { get; set; }
    }
}
