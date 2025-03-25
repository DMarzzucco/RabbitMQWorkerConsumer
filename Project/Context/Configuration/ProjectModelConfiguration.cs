using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Module.Model;

namespace Project.Context.Configuration
{
    public class ProjectModelConfiguration : IEntityTypeConfiguration<ProjectModel>
    {
        public void Configure(EntityTypeBuilder<ProjectModel> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(r => r.Name);
            builder.Property(r => r.Description);

            builder.ToTable("Project");
        }
    }
}
