using AdvWorksAPI.DataAccessEF6;
using AdvWorksAPI.DataAccessEF6.Data;
using AdvWorksAPI.DTOs;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdvWorksAPI
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
            services.AddScoped<AdventureWorksContext>(_ => new AdventureWorksContext(Configuration.GetConnectionString("AdventureWorksContext")));
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddAutoMapper(opts =>
            {
                opts.CreateMap<Product, ProductDTO>().ReverseMap();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
