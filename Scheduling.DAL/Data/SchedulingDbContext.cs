using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Scheduling.DAL.Models;

namespace Scheduling.DAL.Data
{
    public class SchedulingDbContext : DbContext
    {
        public SchedulingDbContext(DbContextOptions<SchedulingDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
