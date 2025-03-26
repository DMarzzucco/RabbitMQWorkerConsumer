using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Configuration.Database.Helper;
using Project.Context;
using Project.Mapper;
using Project.Module.Repository;
using Project.Module.Repository.Interface;
using Project.Module.Services;
using Project.Module.Services.Interface;

namespace Project.Extensions
{
    public static class ServicesBuilderExtensions
    {
        public static IServiceCollection AddServiceBuilderExtensions(this IServiceCollection service, IConfiguration configuration)
        {
            //conection
            var connectionString = configuration.GetConnectionString("Connection");
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("Connection string cannot be null or empty");
            using (var provider = service.BuildServiceProvider())
            {
                var logger = provider.GetRequiredService<ILogger<object>>();
                WaitForConnection.Implement(connectionString, logger).GetAwaiter().GetResult();
            }
            service.AddDbContext<AppDBContext>(op => op.UseNpgsql(connectionString));
            //swagger
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
            //controler
            service.AddControllers();
            //scope
            service.AddScoped<IProjectRepository, ProjectRepository>();
            service.AddScoped<IProjectService, ProjectService>();
            //mapper
            var mappConfig = new MapperConfiguration(cs =>
            {
                cs.AddProfile<MappingProfile>();
            });
            IMapper mapper = mappConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }
}
