using Microsoft.EntityFrameworkCore;
using Segumientos.Web.Data.Entities;
using System.Collections.Generic;

namespace Segumientos.Web.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskL> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }
    }
}

