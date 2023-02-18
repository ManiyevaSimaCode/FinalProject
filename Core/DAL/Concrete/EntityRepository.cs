
using Microsoft.EntityFrameworkCore;

namespace Core.DAL.Concrete
{
    public class EntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, ITable, new()
        where TContext : IdentityDbContext<AppUser>
    {
        private readonly TContext _context;

        public EntityRepository(TContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            
            _context.Set<TEntity>().Remove(entity);


        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
            return exp is null
                ? await query.ToListAsync()
                : await query.Where(exp).ToListAsync();

        }



        public async Task<List<TEntity>> GetAllPaginateAsync(int page, int size, Expression<Func<TEntity, bool>> exp = null, params string[] includes)
        {

            IQueryable<TEntity> query = GetQuery(includes);
            return exp is null
    ? await query.Skip((page - 1) * size).Take(size).ToListAsync()
    : await query.Where(exp).Skip((page - 1) * size).Take(size).ToListAsync();

        }

        public  Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
             return query.Where(exp).FirstOrDefaultAsync();

        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> exp)
        {

            return await _context.Set<TEntity>().AnyAsync(exp);

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

        }

        private IQueryable<TEntity> GetQuery(string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }
    }
}
