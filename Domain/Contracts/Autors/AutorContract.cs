using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts.Autors
{
    public class AutorContract
    {
        public string FullName { get; set; }

        public DateTime BirthdayDate { get; set; }

        public string City { get; set; }

        public string Email { get; set; }
    }
}
