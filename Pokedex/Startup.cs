using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pokedex.Converters;
using Pokedex.Interfaces;
using Pokedex.Parser;
using Pokedex.Repositories;
using Pokedex.Services;
using Pokedex.Validators;


namespace Pokedex
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



            services.AddDbContext<PokedexDbContext>(option =>
                option.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
                .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));

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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
