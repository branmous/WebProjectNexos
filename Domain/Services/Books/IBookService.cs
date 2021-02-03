using Domain.Contracts.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.Books
{
    public interface IBookService
    {
        Task<bool> CreateBook(BookContract request);
        List<BookFilterContract> GetBooks();
        List<BookFilterContract> GetBooks(string filter);
    }
}
