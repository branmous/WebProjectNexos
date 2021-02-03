using Infraestructure.Model.Model;
using System.Linq;

namespace Infraestructure.Repository.Repositories.Books
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly EntityContext context;

        public BookRepository(EntityContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<Book> FilterBooks(string filter)
        {
            return this.context.Books.Where(p => 
                                    p.Autor.FullName.Contains(filter) || 
                                    p.Title.Contains(filter) || 
                                    p.Year.ToString().Contains(filter));
        }
    }
}
