using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MedicineManage.DataAccess.Interfaces;
using MedicineManage.Domain.Models;
using MedicineManage.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
namespace MedicineManage.DataAccess.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;

        public EfRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task<List<T>> GetAllByNameAsync(string name, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if (includesProperties is not null && includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in includesProperties)
                {
                    query = query.Include(included);
                }
            }

            return await query.Where(e => e.Name == name).ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if (includesProperties is not null && includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in includesProperties)
                {
                    query = query.Include(included);
                }
            }

            return await query.Where(e => e.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            return await query.ToListAsync();
        }
        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties)
        {

            IQueryable<T>? query = _entities.AsQueryable();
            if (includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in includesProperties)
                {
                    query = query.Include(included);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }


            return await query.ToListAsync();

        }

        public Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _entities.Add(entity);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _entities.Remove(entity);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _entities.FirstOrDefaultAsync(filter, cancellationToken);
        }
        public async Task CreateDataBaseAsync() =>
                 await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() =>
                 await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() =>
                 await _context.SaveChangesAsync();
    }
}
