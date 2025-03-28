using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tasks.Context;
using Tasks.Mapper;
using Tasks.Module.Repository.Interface;
using Tasks.Module.Repository;
using Tasks.Module.Services;
using Tasks.Module.Services.Interface;
using Tasks.Configuration.Database.Helper;
using MassTransit;
using Tasks.Module.Consumer;

namespace Tasks.Extensions
{
    public static class ServicesBuilderExtensions
    {
        public static IServiceCollection AddServiceBuilderExtensions(this IServiceCollection service, IConfiguration configuration)
        {
            //conection
            var connectionString = configuration.GetConnectionString("Connection");
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("Connection string cannot be null or Empty");

            using (var serviceProiver = service.BuildServiceProvider())
            {
                var logger = serviceProiver.GetRequiredService<ILogger<object>>();
                WaitForConnection.Implement(connectionString, logger).GetAwaiter().GetResult();
            }
            service.AddDbContext<AppDBContext>(op => op.UseNpgsql(connectionString));
            //rabbit mq
            service.AddMassTransit(x =>
            {
                x.AddConsumer<ProjectConsummer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost:5672"), h =>
                    {
                        h.Username("user");
                        h.Password("password");
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
            service.AddMassTransitHostedService();
            //swagger
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
            //controler
            service.AddControllers();
            //scope
            service.AddScoped<ITaskRepository, TaskRepository>();
            service.AddScoped<ITaskService, TaskServices>();
            service.AddScoped<ProjectConsummer>();
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
