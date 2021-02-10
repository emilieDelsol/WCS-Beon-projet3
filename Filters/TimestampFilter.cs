using BeOn.Models;
using System;
using System.Linq;

namespace BeOn.Filters
{
    public class TimestampFilter<T> : IFilter<T> where T : ITimestampable
    {
        public DateTime BeginsAt { get; set; } = DateTime.MaxValue;
        public Boolean Backwards { get; set; } = false;

        public Double Period
        {
            get
            {
                return _periodTimeSpan.TotalMilliseconds;
            }
            set
            {
                if (value <= 0)
                {
                    _periodTimeSpan = TimeSpan.MinValue;
                }
                _periodTimeSpan = TimeSpan.FromMilliseconds(value);
            }
        }
        private TimeSpan _periodTimeSpan = TimeSpan.MinValue;

        public IQueryable<T> Apply(IQueryable<T> entities)
        {
            DateTime endDate;
            if (BeginsAt == DateTime.MaxValue)
            {
                endDate = entities.OrderBy(e => e.Timestamp)
                                  .Select(e => e.Timestamp)
                                  .Last();
            }
            IQueryable<T> filtered;
            if (Backwards)
            {
                endDate = BeginsAt - _periodTimeSpan;
                filtered = entities.Where(entity => BeginsAt >= entity.Timestamp && entity.Timestamp >= endDate);
            }
            else
            {
                endDate = BeginsAt + _periodTimeSpan;
                filtered = entities.Where(entity => endDate >= entity.Timestamp && entity.Timestamp >= BeginsAt);
            }
            return filtered;
        }
    }
}