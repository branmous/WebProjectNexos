using AutoMapper;
using Domain.Contracts.Books;
using Infraestructure.Model.Interfaces;
using Infraestructure.Model.Model;
using Infraestructure.Repository.Repositories.Autors;
using Infraestructure.Repository.Repositories.Books;
using Infraestructure.Repository.Repositories.Editorials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services.Books
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        private IEditorialRepository _editorialRepository;
        private IAutorRepository _autorRepository;
        private IMapper _mapper;
        public BookService(IBookRepository bookRepository,
            IEditorialRepository editorialRepository,
            IAutorRepository autorRepository,
            IMapperDependency mapperDependency)
        {
            _bookRepository = bookRepository;
            _editorialRepository = editorialRepository;
            _autorRepository = autorRepository;
            _mapper = mapperDependency.GetMapper();
        }

        public async Task<bool> CreateBook(BookContract request)
        {
            Autor autor = await _autorRepository.GetByIdAsync(request.AutorId);
            if (autor == null)
            {
                throw new Exception("El autor no está registrado");
            }

            Editorial editorial = await _editorialRepository.GetByIdAsync(request.EditorialId);
            if (editorial == null)
            {
                throw new Exception("La editorial no está registrada");
            }

            if (editorial.MaxBook != -1)
            {
                int count = _editorialRepository.GetCountForEditorial(editorial.Id);
                if (count == editorial.MaxBook)
                {
                    throw new Exception("No es posible registrar el libro, se alcanzó el máximo permitido.");
                }
            }

            Book book = _mapper.Map<Book>(request);
            await _bookRepository.CreateAsync(book);
            return true;
        }
        public List<BookFilterContract> GetBooks()
        {
            IQueryable<Book> books = _bookRepository.GetAll();
            return _mapper.Map<List<BookFilterContract>>(books);
        }

        public List<BookFilterContract> GetBooks(string filter)
        {
            IQueryable<Book> books = _bookRepository.FilterBooks(filter);
            return _mapper.Map<List<BookFilterContract>>(books);
        }

    }
}
