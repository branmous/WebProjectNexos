using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts.Books
{
    public class BookFilterContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int NumberPages { get; set; }

        public int AutorId { get; set; }

        public string AutorName { get; set; }

        public int EditoralId { get; set; }

        public string EditoralName { get; set; }
    }
}
