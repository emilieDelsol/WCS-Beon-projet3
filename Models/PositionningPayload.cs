using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
    [Table("positionning_payload")]
    public class PositionningPayload
    {
        [Column("device_id")]
        public String DeviceId { get; set; }
        public Device Device { get; set; }

        [Column("timestampevent")]
        public DateTime TimestampEvent { get; set; }

        [Column("seq_number")]
        public int SeqNumber { get; set; }

        [Column("computed_latitude")]
        public double ComputedLatitude { get; set; }

        [Column("computed_longitude")]
        public double ComputedLongitude { get; set; }

        [Column("radius")]
        public int Radius { get; set; }

        [Column("source")]
        public int Source { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("frametype")]
        public string Frametype { get; set; }

        [Column("batterylvl")]
        public double Batterylvl { get; set; }

        [Column("timestamppayload")]
        public DateTime TimestampPayload{ get; set; }

        [Column("long")]
        public double Long { get; set; }

        [Column("lat")]
        public int Lat { get; set; }

        [Column("alt")]
        public int Alt { get; set; }

        [Column("hdop")]
        public int Hdop { get; set; }

        [Column("nb_satellites")]
        public int NbSatellites { get; set; }
    }
}
