using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Siteware.Application;
using Siteware.Application.Contracts;
using Siteware.Domain.Concrete.Notification;
using Siteware.Domain.Notification;
using Siteware.Domain.Notification.Contracts;
using Siteware.Domain.Repositories;
using Siteware.Infra.Repositories;
using Siteware.Infra.SqlServer.EF;
using System.Data;

namespace Siteware.Ioc
{
    public class ConfigureIoc
    {
        private readonly IServiceCollection services;
        private readonly IConfiguration configuration;
        public ConfigureIoc(IServiceCollection services, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.services = services;
        }

        public void InjectorDependency()
        {
            DateBase();
            AppServices();
            DomainServices();
            Repositories();
        }

        public void DateBase()
        {
            //EF Context
            services.AddDbContext<SitewareDbContext>(
                  options => options.UseSqlServer(
                      configuration.GetValue<string>("Database:DefaultConnection")));

            services.AddScoped<IDbConnection>(p => p.GetService<SitewareDbContext>().Database.GetDbConnection());
        }

        public void AppServices()
        {
            services.AddScoped<IUserAppService, UserAppService>();
        }

        public void DomainServices()
        {
            //EF Context
            services.AddDbContext<SitewareDbContext>(
                  options => options.UseSqlServer(
                      configuration.GetValue<string>("Database:DefaultConnection")));


            services.AddScoped<INotifierService, NotifierService>();
            services.AddScoped<INotifier, Notifier>();
        }

        public void Repositories()
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
        }


    }
}



