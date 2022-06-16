using InternShipApi.Interfaces;
using InternShipApi.Interfaces.IManager;
using InternShipApi.Interfaces.IRepository;
using InternShipApi.Models;
using InternShipApi.Repository;
using InternShipApi.Services.Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace InternShipApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("PostgresqlConnection");

            services.AddDbContext<InternDatabaseContext>(db => db.UseNpgsql(connectionString));

            services.AddCors();


            services.AddControllers();
        

            services.AddTransient(typeof(ICompanyManager), typeof(CompanyManager));
            services.AddTransient(typeof(ICompanyRepository), typeof(CompanyRepository));
            services.AddTransient(typeof(ICityManager), typeof(CityManager));
            services.AddTransient(typeof(ICityRepository), typeof(CityRepository));


            services.AddAutoMapper(typeof(Startup));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IUserManager), typeof(UserManager));
           
            services.AddTransient(typeof(IInternshipPostingManager), typeof(InternshipPostingManager));
            services.AddTransient(typeof(IInternshipPostingRepository), typeof(InternshipPostingRepository));
            services.AddTransient(typeof(IInternshipPositionManager), typeof(InternshipPositionManager));
            services.AddTransient(typeof(IInternshipPositionRepository), typeof(InternshipPositionRepository));
            services.AddTransient(typeof(IApplicationManager), typeof(ApplicationManager));
            services.AddTransient(typeof(IApplicationRepository), typeof(ApplicationRepository));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InternShipApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InternShipApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
