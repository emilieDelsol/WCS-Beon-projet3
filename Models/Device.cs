using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
    [Table("device")]
    public class Device
    {
        [Column("id_device")]
        [Key]
        public String DeviceId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("pac")]
        public string Pac { get; set; }

        [Column("endproductcertificate")]
        public string EndProductCertificate { get; set; }

        public ICollection<EnvironmentPayload> EnvironmentPayloads { get; set; }
        public ICollection<PositionningPayload> PositionningPayloads { get; set; }
    }
}
