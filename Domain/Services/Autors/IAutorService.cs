using Domain.Contracts.Autors;
using Domain.Contracts.Editorials;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Autors
{
    public interface IAutorService
    {
        Task<bool> CreateAutor(AutorContract request);
        Task<bool> CreateEditorial(EditorialContract request);
    }
}
