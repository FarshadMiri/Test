using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contract.Persistence;
using Test.Application.Services;
using Test.Persistence;
using Test.Persistence.Repositories;

namespace Test.Infrastructure.IOC
{
    public static class ConfigureRegistration
    {
        public static void   ConfigurePersistenceServices(this IServiceCollection services,
     IConfiguration configuration)
        {
            services.AddDbContext<TestDbContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("TestConnection"));
            });


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserServices, UserServices>();


            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IProvinceService, ProvinceService>();


            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityService, CityService>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();

            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IAnswerService, AnswerService>();




            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IProvinceService, ProvinceService>();


            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            





            


        }
    }
}
