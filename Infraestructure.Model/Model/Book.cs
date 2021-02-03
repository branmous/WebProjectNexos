using Infraestructure.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Model.Model
{
    public class Book : IEntity
    {
        
        public int Id { get; set; }
        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int NumberPages { get; set; }


        public int EditorialId { get; set; }

        public virtual Editorial Editorial { get; set; }

        public int AutorId { get; set; }

        public virtual Autor Autor { get; set; }
    }
}
