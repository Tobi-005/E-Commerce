using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            this._context = context;
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListALLAsync()
        {
           return await _context.Set<T>().ToListAsync();
        }

         public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
           return await Applyspecification(spec).FirstOrDefaultAsync();
        }


        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await Applyspecification(spec).ToListAsync();
        }

        public async Task<int> GetCountAsync(ISpecification<T> spec)
        {
           return await Applyspecification(spec).CountAsync();
        }

        private IQueryable<T> Applyspecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

       
    }
}