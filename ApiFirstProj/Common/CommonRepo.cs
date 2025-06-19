using ApiFirstProj.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiFirstProj.Common
{
    public class CommonRepo<T> : ICommonRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context; // Database
        private readonly DbSet<T> _db; //Table

        public CommonRepo(ApplicationDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();

        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T,bool>> condition = null,Func<IQueryable<T>,IQueryable<T>> query = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> db = _db;

            if (query != null)
            {
                db = query(db);
            }
            if (condition != null)
            {
                db = db.Where(condition);
            }

            var response = await db.ToListAsync(cancellationToken);

            return response;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> condition, Func<IQueryable<T>, IQueryable<T>> query = null)
        {
            IQueryable<T> db = _db;

            if (query != null)
            {
                db = query(db);
            }
            var response = await db.FirstOrDefaultAsync(condition);
            return response!;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity, params Expression<Func<T, object>>[] updateProperties)
        {
            _db.Attach(entity);

            foreach (var property in updateProperties)
            {
                _context.Entry(entity).Property(property).IsModified = true;
            }

            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<bool> DeleteViaIdAsync(Guid id)
        {
            var item = await _db.FindAsync(id);
            if (item == null) { return false; }

            _db.Remove(item);

            return await _context.SaveChangesAsync() > 0; //SaveChangesAsync returns an integer if rows were affected
        }

        public async Task<bool> DeleteViaCompKeyAsync(Expression<Func<T,bool>> condition)
        {
            var item = await _db.FirstOrDefaultAsync(condition);
            if (item == null) { return false; }

            _db.Remove(item);

            return await _context.SaveChangesAsync() > 0; //SaveChangesAsync returns an integer if rows were affected
        }
    }
}
