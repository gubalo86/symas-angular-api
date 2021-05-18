using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Symas.SymasSalud.Repositories.SqlServer.Extensions;
using Symas.SymasSalud.Repositories.SqlServer.Mappers;
using Symas.SymasSalud.Services.Extensions;
using System.Text.Json.Serialization;

namespace lf_Package_Core
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

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
                                      builder
                                      .AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();

                                      //builder.WithOrigins("http://example.com",
                                      //                    "http://www.contoso.com");
                                  });
            });

            services.AddControllers()
                .AddJsonOptions(options=> {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services
                .AddMvc()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            services.AddAutoMapper(typeof(SymasSaludMapperProfile));

            services
                .AddSymasSaludDbContext(options => options
                    .UseSqlServer(Configuration.GetConnectionString("SymasSalud"))
                    //.UseSqlServer("Data Source=DESKTOP-OI31OU4;Initial Catalog=dbSymasSalud;Persist Security Info=True;User ID=sa;Password=$gbanuelos86")
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())))
                .AddSymasSaludRepositories()
                .AddSymasSaludServices();
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

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}