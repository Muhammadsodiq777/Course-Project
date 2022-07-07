using Course_Project.Configurations;
using Course_Project.IRepository;

namespace Course_Project.IRepository;

public class UnitOfWork : IUnitOfWork
{
    public readonly DatabaseDBConfig _context;

    private GenericRepository<Country> _countries;

    private GenericRepository<Hotel> _hotels;

    public UnitOfWork(DatabaseDBConfig context)
    {
        _context = context;
    }

    public GenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);
    public GenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);

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
