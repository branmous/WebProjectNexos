using Infraestructure.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Model.Model
{
    public class Editorial : IEntity
    {
        public Editorial()
        {
            Books = new HashSet<Book>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int MaxBook { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Book> Books { get; set; }
    }
}
