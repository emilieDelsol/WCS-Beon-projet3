using BeOn.Models;
using BeOn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeOn.Filters
{
    public class TimestampFilter<T> : IFilter<T> where T : ITimestampable
    {
        public DateTime BeginDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        public Boolean Last { get; set; } = false;

        public IQueryable<T> Apply(IEnumerable<T> entities)
        {
            IEnumerable<T> result;
            if (Last)
            {
                T lastEntity = ApplyLast(entities);
                result = new List<T> { lastEntity };
            }
            else
            {
                result = ApplyBetween(entities);
            }
            return result.AsQueryable();
        }

        public T ApplyLast(IEnumerable<T> entities)
        {
            return entities.OrderBy(entity => entity.Timestamp)
                           .Last();
        }

        public IQueryable<T> ApplyBetween(IEnumerable<T> entities)
        {
            return entities.Where(entity => (BeginDate >= entity.Timestamp) && (entity.Timestamp <= EndDate)) //chager tri , beginDate doit etre <= Timestamp 
                           .AsQueryable();
        }
    }
}
