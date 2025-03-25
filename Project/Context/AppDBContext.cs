using Microsoft.EntityFrameworkCore;
using Project.Context.Configuration;
using Project.Module.Model;

namespace Project.Context
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<ProjectModel> ProjectModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectModelConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
