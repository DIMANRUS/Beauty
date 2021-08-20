using Beauty.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Beauty.API.Contexts {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceWorker> ServicesWorkers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole[] {
                new IdentityRole("Admin"){ NormalizedName = "ADMIN"},
                new IdentityRole("User"){ NormalizedName = "USER"},
                new IdentityRole("Salon"){NormalizedName = "SALON"},
                new IdentityRole("Worker"){NormalizedName = "WORKER"}
            });
            modelBuilder.Entity<Service>().HasData(new Service[]{
                new Service(){ServiceName = "Стрижка", Id = 1 },
                new Service(){ServiceName = "Маникюр", Id = 2 }
            });
            modelBuilder.Entity<Service>().HasIndex(u => u.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}