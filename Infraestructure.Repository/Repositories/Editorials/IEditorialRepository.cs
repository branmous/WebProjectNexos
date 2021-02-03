using Infraestructure.Model.Model;

namespace Infraestructure.Repository.Repositories.Editorials
{
    public interface IEditorialRepository : IGenericRepository<Editorial>
    {
        int GetCountForEditorial(int id);
    }
}
