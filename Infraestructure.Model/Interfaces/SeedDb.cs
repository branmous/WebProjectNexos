using Infraestructure.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.Interfaces
{
    public class SeedDb
    {
        private readonly EntityContext context;
        public SeedDb(EntityContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();
        }
    }
}
