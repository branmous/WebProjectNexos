using Infraestructure.Model.Model;
using System.Linq;

namespace Infraestructure.Repository.Repositories.Books
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        IQueryable<Book> FilterBooks(string filter);
    }
}
