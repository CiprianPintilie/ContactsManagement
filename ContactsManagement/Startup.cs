using System;
using System.IO;
using System.Reflection;
using ContactsManagement.AppStart;
using DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace ContactsManagement
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;
        private bool _inMemoryDatabase;

        public IConfiguration Configuration { get; }

        public Startup(ILogger<Startup> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Bootstrapper.RegisterServices(services);
            ConfigureDbContext(services);
            ConfigureSwagger(services);

            services.AddMvc();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint(Configuration.GetSection("Swagger:Uri").Value, "Contacts management API"));

            if (!_inMemoryDatabase)
                UpdateDatabase(app);

            app.UseMvc();
        }

        private void ConfigureDbContext(IServiceCollection services)
        {
            var inMemoryDatabase = Configuration.GetSection("Database:ContactsManagementDatabase:UseInMemoryDatabase").Get<bool>();

            if (inMemoryDatabase)
            {
                _logger.LogInformation("Using in memory database");
                services.AddDbContext<ContactsManagementDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryContactsManagement"));
            }
            else
            {
                services.AddDbContext<ContactsManagementDbContext>(options =>
                    options.UseSqlServer(Configuration.GetSection("Database:ContactsManagementDatabase:ConnectionString").Value));
            }

            _inMemoryDatabase = inMemoryDatabase;
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new Info {Title = "Contacts management API", Version = "v1"});

                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                    options.IncludeXmlComments(xmlFilePath);
                }
            );
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<ContactsManagementDbContext>())
                {
                    context.Database.Migrate();
                }
            }
            
        }
    }
}
