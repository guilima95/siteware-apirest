using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Siteware.Application;
using Siteware.Application.Contracts;
using Siteware.Application.Contracts.Base;
using Siteware.Domain.Concrete.Notification;
using Siteware.Domain.Notification;
using Siteware.Domain.Notification.Contracts;
using Siteware.Domain.Repositories;
using Siteware.Domain.Repositories.Transaction;
using Siteware.Domain.Services;
using Siteware.Domain.Services.Contracts;
using Siteware.Infra.Repositories;
using Siteware.Infra.Repositories.Transaction;
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
        }

        public void AppServices()
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IPromotionAppService, PromotionAppService>();
            services.AddScoped<ICartAppService, CartAppService>();

            services.AddScoped<ICalculatePriceTotalBase, CalculatePriceTotalBase>();



        }

        public void DomainServices()
        {
            //EF Context
            services.AddDbContext<SitewareDbContext>(
                  options => options.UseSqlServer(
                      configuration.GetValue<string>("Database:DefaultConnection")));


            services.AddScoped<INotifierService, NotifierService>();
            services.AddScoped<INotifier, Notifier>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<ICartService, CartService>();

        }

        public void Repositories()
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<ICartRepository, CartRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


    }
}



