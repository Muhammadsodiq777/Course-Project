
using Course_Project.Configurations;
using Course_Project.Data;
using Course_Project.IRepository;

namespace Course_Project.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DatabaseContext _context;

        private GenericRepository<ApiUser> _user;

        //private GenericRepository<Hotel> _hotels;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public GenericRepository<ApiUser> Users => _user ??= new GenericRepository<ApiUser>(_context);
        //public GenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync(); 
        }
    }
}
