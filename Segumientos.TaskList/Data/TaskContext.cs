using Microsoft.EntityFrameworkCore;
using Segumientos.TaskList.Data.Entities;

namespace Segumientos.TaskList.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskL> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }
    }
}



