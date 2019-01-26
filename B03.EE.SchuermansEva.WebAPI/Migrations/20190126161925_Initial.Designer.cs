﻿// <auto-generated />
using System;
using B03.EE.SchuermansEva.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace B03.EE.SchuermansEva.WebAPI.Migrations
{
    [DbContext(typeof(ActivityServiceContext))]
    [Migration("20190126161925_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("B03.EE.SchuermansEva.Lib.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<int>("CountryId");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<DateTime>("StopDateTime");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.ToTable("Activity");

                    b.HasData(
                        new { Id = 1, CategoryId = 5, CountryId = 2, Created = new DateTime(2019, 1, 26, 17, 19, 25, 717, DateTimeKind.Local), Description = "Family-clycling-tour near Bruges. We start and end at RSS1.", StartDateTime = new DateTime(2019, 5, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), StopDateTime = new DateTime(2019, 5, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), Title = "Bicycleride" },
                        new { Id = 2, CategoryId = 4, CountryId = 11, Created = new DateTime(2019, 1, 26, 17, 19, 25, 717, DateTimeKind.Local), Description = "Visit Berlin in three days. Guided tour around the city, where the east and west part meet eachother", StartDateTime = new DateTime(2019, 4, 22, 7, 30, 0, 0, DateTimeKind.Unspecified), StopDateTime = new DateTime(2019, 4, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), Title = "Easter Citytrip" },
                        new { Id = 3, CategoryId = 5, CountryId = 10, Created = new DateTime(2019, 1, 26, 17, 19, 25, 717, DateTimeKind.Local), Description = "Family-canyon in South France. Everybody who wants to participate, has to be able te swim 25m.", StartDateTime = new DateTime(2019, 6, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), StopDateTime = new DateTime(2019, 6, 10, 16, 30, 0, 0, DateTimeKind.Unspecified), Title = "Gorges de Galamus" }
                    );
                });

            modelBuilder.Entity("B03.EE.SchuermansEva.Lib.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new { Id = 1, CategoryName = "None", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 2, CategoryName = "Crafts", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 3, CategoryName = "Culinary", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 4, CategoryName = "Culture", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 5, CategoryName = "Sports", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 6, CategoryName = "Wellness", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) }
                    );
                });

            modelBuilder.Entity("B03.EE.SchuermansEva.Lib.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("Country");

                    b.HasData(
                        new { Id = 1, CountryName = "Austria", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 2, CountryName = "Belgium", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 3, CountryName = "Bulgaria", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 4, CountryName = "Croatia", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 5, CountryName = "Cyprus", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 6, CountryName = "Czechia", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 7, CountryName = "Denmark", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 8, CountryName = "Estonia", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 9, CountryName = "Finland", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 10, CountryName = "France", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 11, CountryName = "Germany", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 12, CountryName = "Greece", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 13, CountryName = "Hungary", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 14, CountryName = "Ireland", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 15, CountryName = "Italy", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 16, CountryName = "Latvia", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 17, CountryName = "Lithuania", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 18, CountryName = "Luxembourg", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 19, CountryName = "Malta", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 20, CountryName = "Netherlands", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 21, CountryName = "Poland", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 22, CountryName = "Portugal", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 23, CountryName = "Romania", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 24, CountryName = "Slovakia", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 25, CountryName = "Slovenia", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 26, CountryName = "Spain", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 27, CountryName = "Sweden", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) },
                        new { Id = 28, CountryName = "United Kingdom", Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local) }
                    );
                });

            modelBuilder.Entity("B03.EE.SchuermansEva.Lib.Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityId");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("Registration");

                    b.HasData(
                        new { Id = 1, ActivityId = 1, Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local), UserId = 1 },
                        new { Id = 2, ActivityId = 1, Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local), UserId = 2 },
                        new { Id = 3, ActivityId = 1, Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local), UserId = 3 },
                        new { Id = 4, ActivityId = 1, Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local), UserId = 4 },
                        new { Id = 5, ActivityId = 3, Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local), UserId = 1 },
                        new { Id = 6, ActivityId = 3, Created = new DateTime(2019, 1, 26, 17, 19, 25, 718, DateTimeKind.Local), UserId = 2 }
                    );
                });

            modelBuilder.Entity("B03.EE.SchuermansEva.Lib.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDay");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new { Id = 1, BirthDay = new DateTime(1987, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), Created = new DateTime(2019, 1, 26, 17, 19, 25, 719, DateTimeKind.Local), FirstName = "Eva", LastName = "Schuermans" },
                        new { Id = 2, BirthDay = new DateTime(1979, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), Created = new DateTime(2019, 1, 26, 17, 19, 25, 719, DateTimeKind.Local), FirstName = "Stijn", LastName = "Schaballie" },
                        new { Id = 3, BirthDay = new DateTime(2015, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), Created = new DateTime(2019, 1, 26, 17, 19, 25, 719, DateTimeKind.Local), FirstName = "Lore", LastName = "Schaballie" },
                        new { Id = 4, BirthDay = new DateTime(2017, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Created = new DateTime(2019, 1, 26, 17, 19, 25, 719, DateTimeKind.Local), FirstName = "Eppo", LastName = "Schaballie" }
                    );
                });

            modelBuilder.Entity("B03.EE.SchuermansEva.Lib.Models.Activity", b =>
                {
                    b.HasOne("B03.EE.SchuermansEva.Lib.Models.Category", "Category")
                        .WithMany("Activities")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("B03.EE.SchuermansEva.Lib.Models.Country", "Country")
                        .WithMany("Activities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("B03.EE.SchuermansEva.Lib.Models.Registration", b =>
                {
                    b.HasOne("B03.EE.SchuermansEva.Lib.Models.Activity", "Activity")
                        .WithMany("Registrations")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("B03.EE.SchuermansEva.Lib.Models.User", "User")
                        .WithMany("Registrations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
