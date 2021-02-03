using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Model.Model
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Editorial> Editorials { get; set; }
    }
}
