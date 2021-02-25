using MyFinance.Application;
using MyFinance.Application.Contracts;
using MyFinance.Application.UseCases;
using MyFinance.Application.UseCases.Contracts;
using MyFinance.Domain.Concrete.Notification;
using MyFinance.Domain.Notification;
using MyFinance.Domain.Notification.Contracts;
using MyFinance.Domain.Repositories;
using MyFinance.Domain.Repositories.Transaction;
using MyFinance.Infra.Repositories;
using MyFinance.Infra.Repositories.Transaction;
using MyFinance.Infra.SqlServer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyFinance.Ioc
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
            services.AddDbContext<MyFinanceDbContext>(
                  options => options.UseSqlServer(
                      configuration.GetValue<string>("Database:DefaultConnection")));
        }

        public void AppServices()
        {
            services.AddScoped<IUserAppService, UserAppService>();

        }

        public void DomainServices()
        {
            //EF Context
            services.AddDbContext<MyFinanceDbContext>(
                  options => options.UseSqlServer(
                      configuration.GetValue<string>("Database:DefaultConnection")));


            services.AddScoped<INotifierService, NotifierService>();
            services.AddScoped<INotifier, Notifier>();

        }

        public void Repositories()
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}



