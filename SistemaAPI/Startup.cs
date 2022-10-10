using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SistemaAPI.Models;

namespace SistemaAPI
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
            //agregar la cadena de conexión para el proyecto 
            //TODO: Debemos guardar esta cadena por medio de usersecrets.json y no por medio de appsttings.json

            var conn = @"SERVER=DESKTOP-7U6LGFC;DATABASE=SistemaDB;User Id=SistemaActividades; Password=12345";

            services.AddDbContext<SistemaDBContext>(options => options.UseSqlServer(conn));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            //TODO: Revisar si hace falta alguna configuración para uso de JWT

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
