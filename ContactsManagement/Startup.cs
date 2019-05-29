using System;
using System.IO;
using System.Reflection;
using DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ContactsManagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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

            app.UseMvc();
        }

        private void ConfigureDbContext(IServiceCollection services)
        {
            var useInMemoryDb = Configuration.GetSection("Database:ContactsManagementDatabase:UseInMemoryDatabase").Get<bool>();

            if (useInMemoryDb)
            {
                services.AddDbContext<ContactsManagementDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryContactsManagement"));
            }
            else
            {
                services.AddDbContext<ContactsManagementDbContext>(options =>
                    options.UseSqlServer(Configuration.GetSection("Database:ContactsManagementDatabase:ConnectionString").Value));
            }
            
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
    }
}
