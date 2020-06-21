using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser> // since we mentioned AppUser here, no need to write DbSet
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //this allows when we create migrations, to give AppUser a primary key of a string

            // builder.Entity<Product>()
            //     .HasOne(p => p.AppUser)
            //     .WithMany(b => b.Products)
            //     .OnDelete(DeleteBehavior.Cascade)
            //     .IsRequired()
            //     .HasForeignKey(p => p.AppUserId);
        }
    }
}
