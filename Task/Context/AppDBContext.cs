using Microsoft.EntityFrameworkCore;
using Task.Context.Configuration;
using Task.Module.Model;

namespace Task.Context
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
