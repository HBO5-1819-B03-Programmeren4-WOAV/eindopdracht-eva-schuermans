using B03.EE.SchuermansEva.Lib.Models;  
using Microsoft.EntityFrameworkCore;
using System;

namespace B03.EE.SchuermansEva.WebAPI.Models
{
    public class ActivityServiceContext : DbContext
    {
        public ActivityServiceContext(DbContextOptions<ActivityServiceContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().ToTable("Activity");
            modelBuilder.Entity<Category>().ToTable("Category");             
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<User>().ToTable("User")
                .HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Eva",
                    LastName = "Schuermans",
                    BirthDay = new DateTime(1987, 2, 8)
                },
                new User
                {
                    Id = 1,
                    FirstName = "Stijn",
                    LastName = "Schaballie",
                    BirthDay = new DateTime(1979, 11, 21)
                },
                new User
                {
                    Id = 1,
                    FirstName = "Lore",
                    LastName = "Schaballie",
                    BirthDay = new DateTime(2015, 12, 21)
                },
                new User
                {
                    Id = 1,
                    FirstName = "Eppo",
                    LastName = "Schaballie",
                    BirthDay = new DateTime(2017, 11, 11)
                });

            modelBuilder.Entity<Activity>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Category>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Country>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<User>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();
        }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
