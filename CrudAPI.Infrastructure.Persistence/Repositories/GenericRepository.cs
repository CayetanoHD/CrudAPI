using CrudAPI.Core.Application.Interfaces.Repositories;
using CrudAPI.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity>
      where Entity : class
    {
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual async Task<Entity> AddAsync(Entity entity)
        {
            await _context.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<List<Entity>> GetAllAsync()
        {
            return await _context.Set<Entity>().ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(int id)
        {
            return await _context.Set<Entity>().FindAsync(id);
        }

        public virtual async Task<List<Entity>> GetWithIncludeAsync(List<string> properties)
        {
            var query = _context.Set<Entity>().AsQueryable();

            foreach (var property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();
        }

        public virtual async Task UpdateAsync(Entity entity, int id)
        {
            var response = await _context.Set<Entity>().FindAsync(id);

            _context.Entry(response).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Entity entity)
        {
            _context.Set<Entity>().Remove(entity);

            await _context.SaveChangesAsync();
        }
    }

}
