using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
    [Table("device")]
    public class Device
    {
        [Column("id_device")]
        public string Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("pac")]
        public string Pac { get; set; }

        [Column("endproductcertificate")]
        public string EndProductCertificate { get; set; }
        public ICollection<EnvironmentPayload> environmentPayloads { get; set; }
        public ICollection<PositionningPayload> positionningPayloads { get; set; }


    }
}
