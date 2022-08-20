using Microsoft.EntityFrameworkCore;

namespace Catalog2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }

        public DbSet<TaskItem> Tasks { get; set; } 
    }
}