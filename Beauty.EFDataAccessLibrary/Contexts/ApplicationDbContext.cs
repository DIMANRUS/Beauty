using Beauty.EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Beauty.EFDataAccessLibrary.Contexts {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public new DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceWorker> ServicesWorkers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole[] {
                new IdentityRole("ADMIN"){ NormalizedName = "ADMIN"},
                new IdentityRole("USER"){ NormalizedName = "USER"},
                new IdentityRole("SALON"){NormalizedName = "SALON"},
                new IdentityRole("WORKER"){NormalizedName = "WORKER"}
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