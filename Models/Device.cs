using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
    [Table("device")]
    public  class Device
    {
        [Column("id_device")]
        [Key]
        public virtual String DeviceId { get; set; }

        [Column("name")]
        public virtual string Name { get; set; }

        [Column("pac")]
        public virtual string Pac { get; set; }

        [Column("endproductcertificate")]
        public virtual string EndProductCertificate { get; set; }
        public virtual ICollection<EnvironmentPayload> EnvironmentPayloads { get; set; }
        public virtual ICollection<PositionningPayload> PositionningPayloads { get; set; }
       
    }
}
