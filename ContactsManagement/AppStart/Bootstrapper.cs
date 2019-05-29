using BusinessLayer.Interop;
using BusinessLayer.Services;
using DataAccessLayer.Interop;
using DataAccessLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsManagement.AppStart
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterDataAccessServices(services);
            RegisterBusinessServices(services);
        }
        
        private static void RegisterDataAccessServices(IServiceCollection services)
        {
            services.AddScoped<IContactCommand, ContactCommand>();
            services.AddScoped<IContactQuery, ContactQuery>();
        }

        private static void RegisterBusinessServices(IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
        }
    }
}
