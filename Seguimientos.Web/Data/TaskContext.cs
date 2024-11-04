using Microsoft.EntityFrameworkCore;
using Seguimientos.Web.Data.Entities;
using Segumientos.Web.Data.Entities;
using System.Collections.Generic;

namespace Segumientos.Web.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskL> Tasks { get; set; }
        public DbSet<TipCalculator> TipCalculators { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }
    }
}

