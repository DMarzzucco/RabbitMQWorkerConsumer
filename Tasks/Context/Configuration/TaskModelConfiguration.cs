using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasks.Module.Model;

namespace Tasks.Context.Configuration
{
    public class TaskModelConfiguration : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(r => r.Name).IsRequired();
            builder.ToTable("Task");
        }
    }
}