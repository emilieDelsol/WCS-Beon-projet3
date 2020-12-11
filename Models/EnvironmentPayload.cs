using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
    [Table("environment_payload")]
    public class EnvironmentPayload
    {
        /*[Column("id_device")]
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
        public double batterylvl {get; set; }

        [Column("timestamppayload")]
        public DateTime datePayload { get; set; }

        [Column("event_type")]
        public string eventType { get; set; }

        [Column("tmax")]
        public int tmax { get; set; }

        [Column("tmin")]
        public int tmin { get; set; }

        [Column("tmean")]
        public int tmean { get; set; }

        [Column("total_alert_duration")]
        public int alert_duration { get; set; }
      
        [Column("smax")]
        public double smax { get; set; }

        [Column("total_shock")]
        public double totalshock { get; set; }

        [Column("cptshockovlastperiod")]
        public int cptshockovlastperiod { get; set; }
    }
}
