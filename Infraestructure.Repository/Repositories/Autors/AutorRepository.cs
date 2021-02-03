using Infraestructure.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repository.Repositories.Autors
{
    public class AutorRepository : GenericRepository<Autor>, IAutorRepository
    {
        private readonly EntityContext context;

        public AutorRepository(EntityContext context) : base(context)
        {
            this.context = context;
        }
    }
}
