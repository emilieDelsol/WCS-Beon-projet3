using System.Linq;

namespace BeOn.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> All { get; }

        T Find(T entity);
    }
}
