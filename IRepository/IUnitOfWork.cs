using Course_Project.Data;
using Course_Project.Repository;

namespace Course_Project.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        GenericRepository<ApiUser> Users { get; }
        /*GenericRepository<Hotel> Hotels { get; }*/
        Task SaveAsync();

    }
}
