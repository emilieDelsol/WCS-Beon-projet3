using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeOn.Models
{
    public class User
    {
        [Column("id_users")]
        [Key]
        public String UserId { get; set; }

        [Column("firstname")]
        public String FirstName { get; set; }

        [Column("surname")]
        public String LastName { get; set; }

        [Column("mail")]
        public String EmailAddress { get; set; }

        [Column("username")]
        public String Name { get; set; }

        [Column("id_roles")]
        [ForeignKey("Role")]
        public String RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
