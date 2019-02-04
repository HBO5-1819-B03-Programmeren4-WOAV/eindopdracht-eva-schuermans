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
            modelBuilder.Entity<Activity>().ToTable("Activity")
                .HasData(
                new Activity
                {
                    Id = 1,
                    Title = "Bicycleride",
                    Description = "Family-clycling-tour near Bruges. We start and end at RSS1.",
                    StartDateTime = new DateTime(2019, 5, 1, 13, 30, 0),
                    StopDateTime = new DateTime(2019, 5, 1, 17, 0, 0),
                    CategoryId = 5,
                    CountryId = 2,
                },
                new Activity
                {
                    Id = 2,
                    Title = "Easter Citytrip",
                    Description = "Visit Berlin in three days. Guided tour around the city, where the east and west part meet eachother.",
                    StartDateTime = new DateTime(2019, 4, 22, 7, 30, 0),
                    StopDateTime = new DateTime(2019, 4, 21, 20, 00, 0),
                    CategoryId = 4,
                    CountryId = 11,
                },
                new Activity
                {   
                    Id = 3,
                    Title = "Gorges de Galamus",
                    Description = "Family-canyon in South France. Everybody who wants to participate, has to be able te swim 25m.",
                    StartDateTime = new DateTime(2019, 6, 10, 14, 0, 0),
                    StopDateTime = new DateTime(2019, 6, 10, 16, 30, 0),
                    CategoryId = 5,
                    CountryId = 10,
                });

            for (int i = 0; i < Category.CategoryNames.Count; i++)
            {
                string category = Category.CategoryNames[i];
                modelBuilder.Entity<Category>().ToTable("Category")
                    .HasData(  
                    new Category
                    {
                        Id = i + 1,
                        CategoryName = category
                    });
            }
            
            for (int j = 0; j < Country.CountryNames.Count; j++)
            {
                string country = Country.CountryNames[j];
                modelBuilder.Entity<Country>().ToTable("Country")
                    .HasData(
                    new Country
                    {
                        Id = j + 1,
                        CountryName = country
                    });
            }
           
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
                    Id = 2,
                    FirstName = "Stijn",
                    LastName = "Schaballie",
                    BirthDay = new DateTime(1979, 11, 21)
                },
                new User
                {
                    Id = 3,
                    FirstName = "Lore",
                    LastName = "Schaballie",
                    BirthDay = new DateTime(2015, 12, 21)
                },
                new User
                {
                    Id = 4,
                    FirstName = "Eppo",
                    LastName = "Schaballie",
                    BirthDay = new DateTime(2017, 11, 11)
                });

            modelBuilder.Entity<Registration>().ToTable("Registration")
               .HasData(
               new Registration { Id = 1, ActivityId = 1, UserId = 1 },
               new Registration { Id = 2, ActivityId = 1, UserId = 2 },
               new Registration { Id = 3, ActivityId = 1, UserId = 3 },
               new Registration { Id = 4, ActivityId = 1, UserId = 4 },
               new Registration { Id = 5, ActivityId = 3, UserId = 1 },
               new Registration { Id = 6, ActivityId = 3, UserId = 2 });

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

            modelBuilder.Entity<Registration>()
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
        public DbSet<Registration> Registrations { get; set; }
    }
}
