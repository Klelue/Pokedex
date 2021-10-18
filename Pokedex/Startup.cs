using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pokedex.Abstractions.Converters;
using Pokedex.Abstractions.Parsers;
using Pokedex.Abstractions.Services;
using Pokedex.Abstractions.Validators;
using Pokedex.Api.Middleware;
using Pokedex.Converters;
using Pokedex.Database.Abstractions.Repositories;
using Pokedex.Database.Contexts;
using Pokedex.Database.Repositories;
using Pokedex.Parser;
using Pokedex.Services;
using Pokedex.Validators;

namespace Pokedex.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IPokedexRepository, PokedexRepository>();
            services.AddScoped<IImportService, ImportService>();
            services.AddScoped<IFileValidator, FileValidator>();
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<IPokemonValidator, PokemonValidator>();
            services.AddScoped<ICsvToStringConverter, CsvToStringConverter>();
            services.AddScoped<IStringToPokemonParser, StringToPokemonParser>();
            services.AddScoped<IRequestValidator,RequestValidator>();
            services.AddMvc();


            services.AddDbContext<PokedexDbContext>(option =>
                option.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pokedex", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokedex v1"));
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

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
