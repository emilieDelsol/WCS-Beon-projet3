using BeOn.Models;
using System;
using System.Linq;

namespace BeOn.Filters
{
    public class TimestampFilter<T> : IFilter<T> where T : ITimestampable
    {
        public DateTime BeginsAt { get; set; } = DateTime.MaxValue;
        public Boolean Backwards { get; set; } = true;

        public Double Period
        {
            get
            {
                return _periodTimeSpan.TotalMilliseconds;
            }
            set
            {
                _periodTimeSpan = TimeSpan.FromMilliseconds(value);
            }
        }
        private TimeSpan _periodTimeSpan = TimeSpan.FromMilliseconds(0);

        public IQueryable<T> Apply(IQueryable<T> entities)
        {
            DateTime endDate;
            if (BeginsAt == DateTime.MaxValue)
            {
                BeginsAt = entities.OrderBy(e => e.Timestamp)
                                   .Select(e => e.Timestamp)
                                   .Last();
            }
            IQueryable<T> filtered;
            if (Backwards)
            {
                endDate = BeginsAt - _periodTimeSpan;
                filtered = entities.Where(entity => entity.Timestamp <= BeginsAt && entity.Timestamp >= endDate);
            }
            else
            {
                endDate = BeginsAt + _periodTimeSpan;
                filtered = entities.Where(entity => entity.Timestamp <= endDate && entity.Timestamp >= BeginsAt);
            }
            return filtered;
        }
    }
}