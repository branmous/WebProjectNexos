using Domain.Contracts;
using Domain.Contracts.Books;
using Domain.Services.Books;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService autorService)
        {
            _bookService = autorService;
        }


        [HttpPost]
        [Route("CreateBook")]
        public async Task<Response<bool>> CreateBook(BookContract request)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.Data = await _bookService.CreateBook(request);
            }
            catch (Exception ex)
            {
                response.Header.Code = 500;
                response.Header.Message = ex.Message;
            }

            return response;
        }

        [HttpGet]
        [Route("GetBooks")]
        public async Task<Response<List<BookFilterContract>>> GetBooks(string filter)
        {
            Response<List<BookFilterContract>> response = new Response<List<BookFilterContract>>();
            try
            {
                if (string.IsNullOrEmpty(filter))
                {
                    response.Data = _bookService.GetBooks();
                }
                else
                {
                    response.Data = _bookService.GetBooks(filter);
                }
                
            }
            catch (Exception ex)
            {
                response.Header.Code = 500;
                response.Header.Message = ex.Message;
            }

            return response;
        }
    }
}
