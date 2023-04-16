using AutoMapper;
using FordInternHW2.CustomService;
using FordInternHW2.Data.Model;
using FordInternHW2.Data.Repository.Abstract;
using FordInternHW2.Data.Repository.Concrete;
using FordInternHW2.Data.UnitOfWork.Abstract;
using FordInternHW2.Data.UnitOfWork.Concrete;
using FordInternHW2.Service.Abstract;
using FordInternHW2.Service.Concrete;
using FordInternHW2.Service.Mapper;

namespace FordInternHW2.Extension
{
    public static class StartUpExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            // uow
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();
            services.AddSingleton<SingletonService>();
        }

        public static void AddMapperService(this IServiceCollection services)
        {
            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }


        public static void AddBussinessServices(this IServiceCollection services)
        {
            // repos
            services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();
            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();

            // services
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenManagementService, TokenManagementService>();
        }
    }
}
