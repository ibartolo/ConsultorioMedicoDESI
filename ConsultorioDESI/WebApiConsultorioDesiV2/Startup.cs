using Microsoft.OpenApi.Models;
using Catalogs.Application;
using Institutions.Application;
using Catalogs.Proxy;
using Institute.Proxy;
namespace WebApiConsultorioDesiV2
{
    public class Startup
    {
        public Startup()
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {  //modifique los addscoped
            services.AddScoped<ICatalogsProxy, CatalogsProxy>();
            services.AddScoped<ICatalogsApp, CatalogsApp>();
            services.AddScoped<IInstituteProxy, InstituteProxy>();
            services.AddScoped<IInstituteApp, InstituteApp>();

            services.AddControllers();

            // Swagger/OpenAPI
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPiConsultorioDesiV2", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Always enable Swagger UI in production too (per hosting support guidance).
            // If you want to restrict access, protect the Swagger endpoints with auth or a reverse-proxy rule.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiConsultorioDesiV2 v1");
                c.RoutePrefix = "swagger"; // access at /swagger/index.html
            });

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
