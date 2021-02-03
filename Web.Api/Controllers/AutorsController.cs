using Domain.Contracts;
using Domain.Contracts.Autors;
using Domain.Contracts.Editorials;
using Domain.Services.Autors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorsController : ControllerBase
    {
        private readonly IAutorService _autorService;
        public AutorsController(IAutorService autorService)
        {
            _autorService = autorService;
        }


        [HttpPost]
        [Route("CreateAutor")]
        public async Task<Response<bool>> CreateAutor(AutorContract request)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.Data = await _autorService.CreateAutor(request);
            }
            catch (Exception ex)
            {
                response.Header.Code = 500;
                response.Header.Message = ex.Message;
            }

            return response;
        }

        [HttpPost]
        [Route("CreateEditorial")]
        public async Task<Response<bool>> CreateEditorial(EditorialContract request)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.Data = await _autorService.CreateEditorial(request);
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
