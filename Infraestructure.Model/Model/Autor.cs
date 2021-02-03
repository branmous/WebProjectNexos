using Infraestructure.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace Infraestructure.Model.Model
{
    public class Autor : IEntity
    {
        public Autor()
        {
            Books = new HashSet<Book>();
        }
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime BirthdayDate { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Book> Books { get; set; }
    }
}
