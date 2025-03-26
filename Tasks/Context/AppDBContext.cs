using Microsoft.EntityFrameworkCore;
using Tasks.Context.Configuration;
using Tasks.Module.Model;

namespace Tasks.Context
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<TaskModel> TaskModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskModelConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
