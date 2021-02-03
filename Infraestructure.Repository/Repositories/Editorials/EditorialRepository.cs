using Infraestructure.Model.Model;
using System.Linq;

namespace Infraestructure.Repository.Repositories.Editorials
{
    public class EditorialRepository : GenericRepository<Editorial>, IEditorialRepository
    {
        private readonly EntityContext context;

        public EditorialRepository(EntityContext context) : base(context)
        {
            this.context = context;
        }

        public int GetCountForEditorial(int id)
        {
            return this.context.Books.Where(bo => bo.EditorialId == id).Count();
        }
    }
}
