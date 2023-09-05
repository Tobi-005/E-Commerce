
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        
        Task<T> GetByIDAsync(int id);
    
        Task<IReadOnlyList<T>> ListALLAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        Task<int> GetCountAsync(ISpecification<T> spec);
    }
}