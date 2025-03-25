using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Module.Model;

namespace Task.Context.Configuration
{
    public class TaskModelConfiguration : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.ProjectId).IsRequired();

            builder.ToTable("Task");
        }
    }
}