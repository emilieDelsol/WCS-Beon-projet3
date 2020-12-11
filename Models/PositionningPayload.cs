using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
    [Table("positionning_payload")]
    public class PositionningPayload
    {
          /*  [Column("id_device")]
            public string device_Id { get; set; }*/

            [Column("timestampevent")]
            public DateTime dateEvent { get; set; }

            [Column("seq_number")]
            public int Id { get; set; }

            [Column("computed_latitude")]
            public double latitude { get; set; }

            [Column("computed_longitude")]
            public double longitude { get; set; }

            [Column("radius")]
            public int radius { get; set; }

            [Column("source")]
            public int source { get; set; }

            [Column("status")]
            public int status { get; set; }

            [Column("frametype")]
            public string frametype { get; set; }

            [Column("batterylvl")]
            public double batterylvl { get; set; }

            [Column("timestamppayload")]
            public DateTime datePayload { get; set; }

            [Column("long")]
            public double longs { get; set; }

            [Column("lat")]
            public int lat { get; set; }

            [Column("alt")]
            public int tmax { get; set; }

            [Column("hdop")]
            public int tmin { get; set; }

            [Column("nb_sattelites")]
            public int tmean { get; set; }
    }
}
