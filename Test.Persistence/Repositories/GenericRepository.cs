using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contract.Persistence;

namespace Test.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TestDbContext _context;
        public GenericRepository(TestDbContext context)
        {
            _context = context;   
        }
        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity); 
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);   
            await _context.SaveChangesAsync();  
        }

        public async Task<T> FindById(object id)
        {
           return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
            
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
