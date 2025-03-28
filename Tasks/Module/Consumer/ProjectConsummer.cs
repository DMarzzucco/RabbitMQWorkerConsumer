using MassTransit;

namespace Tasks.Module.Consumer
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
    public class ProjectConsummer : IConsumer<ProjectModel>
    {
        public async Task Consume(ConsumeContext<ProjectModel> context)
        {
            var project = context.Message;
            Console.WriteLine($"Proyecto recibido: {project.Name}");

            if (project.Name.Any(char.IsDigit))
            {
                await context.RespondAsync(new { Status = "Error", Message = "Proyecto no aprovado porque tiene numeros" });
            }
            await context.RespondAsync(new { Status = "Success", Message = "Proyect aprovado, putinsky" });
        }
    }
}
