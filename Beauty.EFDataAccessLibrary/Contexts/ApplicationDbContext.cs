using Beauty.EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Beauty.EFDataAccessLibrary.Contexts {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public new DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<WorkerService> WorkerServices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            #region Roles
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole[] {
                new IdentityRole("ADMIN"){ NormalizedName = "ADMIN"},
                new IdentityRole("USER"){ NormalizedName = "USER"},
                new IdentityRole("SALON"){NormalizedName = "SALON"},
                new IdentityRole("WORKER"){NormalizedName = "WORKER"}
            });
            #endregion
            #region Services ServiceCategories
            modelBuilder.Entity<Service>().HasData(new Service[]{
                new Service(){ServiceName = "Кроп", Id = 1, SeviceCategoryId = 1},
                new Service(){ServiceName = "Флет-топ", Id = 2, SeviceCategoryId = 1 },
                new Service(){ServiceName = "Маникюр", Id = 3, SeviceCategoryId = 2 }
            });
            modelBuilder.Entity<ServiceCategory>().HasData(new ServiceCategory[]{
                new ServiceCategory(){Id = 1, CategoryName="Стрижка"},
                new ServiceCategory(){Id = 2, CategoryName="Маникюр"}
            });
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}