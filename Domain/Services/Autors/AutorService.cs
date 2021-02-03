using AutoMapper;
using Domain.Contracts.Autors;
using Domain.Contracts.Editorials;
using Infraestructure.Model.Interfaces;
using Infraestructure.Model.Model;
using Infraestructure.Repository.Repositories.Autors;
using Infraestructure.Repository.Repositories.Editorials;
using System.Threading.Tasks;

namespace Domain.Services.Autors
{
    public class AutorService : IAutorService
    {
        private IAutorRepository _autorRepository;
        private IEditorialRepository _editorialRepository;
        private IMapper _mapper;
        public AutorService(IAutorRepository autorRepository,
            IEditorialRepository editorialRepository,
            IMapperDependency mapperDependency)
        {
            _autorRepository = autorRepository;
            _editorialRepository = editorialRepository;
            _mapper = mapperDependency.GetMapper();
        }

        public async Task<bool> CreateAutor(AutorContract request)
        {
            Autor autor = _mapper.Map<Autor>(request);
            await _autorRepository.CreateAsync(autor);
            return true;
        }

        public async Task<bool> CreateEditorial(EditorialContract request)
        {
            Editorial editorial = _mapper.Map<Editorial>(request);
            await _editorialRepository.CreateAsync(editorial);
            return true;
        }
    }
}
