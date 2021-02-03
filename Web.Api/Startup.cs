using Infraestructure.Model.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Repository.Repositories.Books;
using Domain.Services.Books;
using Infraestructure.Model.Interfaces;
using Infraestructure.Repository.Repositories.Autors;
using Web.Api.Config;
using Domain.Services.Autors;
using Infraestructure.Repository.Repositories.Editorials;

namespace Web.Api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "MyPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(
                            "https://localhost:44311",
                            "https://localhost:5001")
                                .WithMethods("PUT", "DELETE", "GET", "POST");
                    });
            });

            services.AddTransient<SeedDb>();
            services.AddTransient<IMapperDependency, MapperClient>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<IEditorialRepository, EditorialRepository>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAutorService, AutorService>();
            

            services.AddDbContext<EntityContext>(cfg =>
            {
                cfg.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
            });

            AutomapperConfig.CreateMaps();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
