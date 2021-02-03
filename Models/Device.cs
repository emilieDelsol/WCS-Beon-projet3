using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeOn.Models
{
    [Table("device")]
    public class Device
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
        public virtual ICollection<DeviceEnvironment> EnvironmentPayloads { get; set; }
        public virtual ICollection<DevicePositionning> PositionningPayloads { get; set; }
       
    }
}
