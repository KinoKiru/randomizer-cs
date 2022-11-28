using Randomizer.DataAccess;
using Randomizer.DataAccess.Repository.IRepository;

namespace Randomiz.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        /// <summary>
        /// unit of work can be reused
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
