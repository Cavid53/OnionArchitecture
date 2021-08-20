using DomainLayer.Common;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : AuditingEntity
    {
        private readonly IAppDbContext _context;
        public Repository(IAppDbContext context)
        {
            _context = context;
        }
        public async Task Delete(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentException("Entity");
            }
            _context.GetDbSet<T>().Remove(entity);
            await _context.SaveChangesAsync();
            
        }

        public T Get(int id)
        {
            return _context.GetDbSet<T>().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.GetDbSet<T>().AsEnumerable();
        }

        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }
            _context.GetDbSet<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }
            _context.GetDbSet<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
