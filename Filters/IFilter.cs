using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Filters
{
    public interface IFilter<T>
    {
        IQueryable<T> Apply(IEnumerable<T> entities);
    }
}
