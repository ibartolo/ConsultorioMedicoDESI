using Microsoft.OpenApi.Models;
using Catalogs.Application;
using Institutions.Application;
using Consultation.Application;
using Patient.Application;
using User.Application;
using FiscalData.Application;
using Treatment.Application;
using Package.Application;
using Catalogs.Proxy;
using Institute.Proxy;
using Consultation.Proxy;
using Patient.Proxy;
using User.Proxy;
using FiscalData.Proxy;
using Treatment.Proxy;
using Package.Proxy;

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
            services.AddScoped<IConsultationProxy, ConsultationProxy>();
            services.AddScoped<IConsultationApp, ConsultationApp>();
            services.AddScoped<IPatientProxy, PatientProxy>();
            services.AddScoped<IPatientApp, PatientApp>();
            services.AddScoped<IUserProxy, UserProxy>();
            services.AddScoped<IUserApp, UserApp>();
            services.AddScoped<IFiscalDataProxy, FiscalDataProxy>();
            services.AddScoped<IFiscalDataApp, FiscalDataApp>();
            services.AddScoped<ITreatmentProxy, TreatmentProxy>();
            services.AddScoped<ITreatmentApp, TreatmentApp>();
            services.AddScoped<IPackageProxy, PackageProxy>();
            services.AddScoped<IPackageApp, PackageApp>();
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
