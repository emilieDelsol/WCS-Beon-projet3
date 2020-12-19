using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
    [Table("environment_payload")]
    public class EnvironmentPayload
    {
        [Column("id_device")]
        public String DeviceId { get; set; }
        public virtual Device Device { get; set; }

        [Column("timestampevent")]
        public DateTime TimestampEvent { get; set; }
        public String TimestampEventToString { get { return TimestampEvent.ToString(@"MM/dd/yyyy HH\:mm\:ss.fff"); } }

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
        public double Batterylvl {get; set; }

        [Column("timestamppayload")]
        public DateTime DatePayload { get; set; }

        [Column("event_type")]
        public string EventType{ get; set; }

        [Column("tmax")]
        public int Tmax { get; set; }

        [Column("tmin")]
        public int Tmin { get; set; }

        [Column("tmean")]
        public int Tmean { get; set; }

        [Column("total_alert_duration")]
        public int TotalAlertDuration { get; set; }
      
        [Column("smax")]
        public double Smax { get; set; }

        [Column("total_shock")]
        public double TotalShock { get; set; }

        [Column("cptshockovlastperiod")]
        public int Cptshockovlastperiod { get; set; }
    }
}
