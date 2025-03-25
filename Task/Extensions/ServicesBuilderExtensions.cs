using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task.Context;
using Task.Mapper;

namespace Task.Extensions
{
    public static class ServicesBuilderExtensions
    {
        public static IServiceCollection AddServiceBuilderExtensions(this IServiceCollection service, IConfiguration configuration)
        {
            //conection
            var connectionString = configuration.GetConnectionString("Connection");
            service.AddDbContext<AppDBContext>(op => op.UseNpgsql(connectionString));
            //swagger
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
            //controler
            service.AddControllers();
            //scope
            // service.AddScoped<IProjectRepository, ProjectRepository>();
            // service.AddScoped<IProjectService, ProjectService>();
            //swagger
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
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
