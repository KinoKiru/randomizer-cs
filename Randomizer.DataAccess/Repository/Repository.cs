using Microsoft.EntityFrameworkCore;
using Randomizer.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

namespace Randomizer.DataAccess.Repository
{

    /// <summary>Generic class for interacting with data</summary>
    /// <typeparam name="T">Needs to be instance of class</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        //Make reuseable database repo
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;


        /// <summary>Initializes a new instance of the <see cref="Repository{T}" /> class.</summary>
        /// <param name="context">The context.</param>
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }


        /// <summary>add command</summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }


        /// <summary>returns all items based on generic type</summary>
        /// <returns>
        ///   List<T>
        /// </returns>
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet.AsQueryable();
            return query.ToList();
        }


        /// <summary>example func = c =&gt; c.Id == Id</summary>
        /// <param name="filter"></param>
        /// <returns>
        ///   Item<T>
        /// </returns>
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            //make query based on type probs model
            IQueryable<T> query = dbSet.AsQueryable();
            //make where query
            query = query.Where(filter);
            //return first or default
            return query.FirstOrDefault();
        }


        /// <summary>Removes the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }


        /// <summary>Removes the range.</summary>
        /// <param name="entities">The entities.</param>
        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
