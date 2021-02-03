using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> All { get; }

        T Find(T entity);
    }
}
