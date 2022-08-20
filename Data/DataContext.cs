using Microsoft.EntityFrameworkCore;

namespace Catalog2.Data
{
    public class DataContext : DbContext
    {

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        // { 
        //     optionsBuilder.UseSqlite(@"Data Source=/User/aibar/TaskItem.db"); 
        // }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }

        public DbSet<TaskItem> Tasks { get; set; } 
        public DbSet<Project> Projects { get; set; } 
    }
}