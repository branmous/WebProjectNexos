using AutoMapper;
using Domain.Contracts.Autors;
using Domain.Contracts.Books;
using Domain.Contracts.Editorials;
using Infraestructure.Model.Model;

namespace Domain.Config
{
    public class AutomapperConfig
    {
        public static IMapper CreateMapper()
        {
            var config = CreateConfiguration();
            return config.CreateMapper();
        }

        public static MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookContract>().ReverseMap();
                cfg.CreateMap<Book, BookFilterContract>()
                .ForMember(dest => dest.AutorName, src => src.MapFrom(m => m.Autor.FullName))
                .ForMember(dest => dest.EditoralName, src => src.MapFrom(m => m.Editorial.Name));
                cfg.CreateMap<Autor, AutorContract>().ReverseMap();
                cfg.CreateMap<Editorial, EditorialContract>().ReverseMap();
            });

            return config;
        }
    }
}
