using Microsoft.EntityFrameworkCore;
using RentFlatApi.Infrastructure.Model;

namespace RentFlatApi.Infrastructure.Context
{
    public class RentContext : DbContext
    {
        public DbSet<Flat> Flat { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Address> Address { get; set; }

        public RentContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=dbo.RentFlatApi.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flat>()
                .HasMany(x => x.Images)
                .WithOne(y => y.Flat)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flat>()
                .HasOne(x => x.Owner)
                .WithMany(y => y.Flats)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flat>()
                .HasOne(x => x.Tenant)
                .WithOne(y => y.Flat)
                .HasForeignKey<Tenant>(z => z.Id);
        }
    }
}