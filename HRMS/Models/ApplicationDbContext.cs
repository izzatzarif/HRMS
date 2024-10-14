using Microsoft.EntityFrameworkCore;
using HRMS.Models;

namespace HRMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Training> Trainings { get; set; }

        // Tiada ToTable() diperlukan untuk In-Memory Database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfigurasi tambahan (jika perlu) boleh ditambah di sini
        }
    }
}
