using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeOn.Models
{
    [Table("positionning_payload")]
    public class PositionningPayload
    {
        [Column("id_device")]
        public String DeviceId { get; set; }
        public virtual Device Device { get; set; }

        [Column("timestampevent")]
        public DateTime TimestampEvent { get; set; }

        [Column("seq_number")]
        public int SeqNumber { get; set; }

        [Column("computed_latitude")]
        public double ComputedLatitude { get; set; }
        public string ComputedLatitudeFormatted { get { return Convert.ToString(Math.Round(ComputedLatitude, 6)).Replace(",", "."); } }

        [Column("computed_longitude")]
        public double ComputedLongitude { get; set; }
        public string ComputedLongitudeFormatted { get { return Convert.ToString(Math.Round(ComputedLongitude, 6)).Replace(",", "."); } }

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
        public DateTime TimestampPayload { get; set; }
        [Column("event_type")]
        public string EventType { get; set; }
        [Column("long")]
        public double Long { get; set; }

        [Column("lat")]
        public double Lat { get; set; }

        [Column("alt")]
        public int Alt { get; set; }

        [Column("hdop")]
        public int Hdop { get; set; }

        [Column("nb_satellites")]
        public int NbSatellites { get; set; }
    }
}
