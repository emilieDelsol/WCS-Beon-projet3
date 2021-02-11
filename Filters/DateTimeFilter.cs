using BeOn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Filters
{
	public class DateTimeFilter<T> : IFilter<T> where T : ITimestampable
	{
		public DateTime BeginDate { get; set; }
		public DateTime EndDate { get; set; }
		public IQueryable<T> Apply(IQueryable<T> entities)
		{
			IQueryable<T> entitiesBetween = entities.Where(e => e.Timestamp <= EndDate && e.Timestamp >= BeginDate);
			return entitiesBetween;
		}
	}
}
