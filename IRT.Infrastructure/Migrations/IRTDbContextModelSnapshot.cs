﻿// <auto-generated />
using System;
using IRT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IRT.Infrastructure.Migrations
{
    [DbContext(typeof(IRTDbContext))]
    partial class IRTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IRT.Domain.Entities.DrugstoreViewModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FoundationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("NeighborhoodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("RoundTheClock")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("NeighborhoodId");

                    b.ToTable("Drugstores");
                });

            modelBuilder.Entity("IRT.Domain.Entities.Neighborhood", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Neighborhoods");
                });

            modelBuilder.Entity("IRT.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("948564b2-64cd-4f4d-a5a9-18ed9258c24a"),
                            Email = "admin@instituto.com",
                            Login = "admin",
                            Name = "Evaluator",
                            Password = "72AC31325B6FAFF1720A1F9D4D527C9C"
                        });
                });

            modelBuilder.Entity("IRT.Domain.Entities.DrugstoreViewModel", b =>
                {
                    b.HasOne("IRT.Domain.Entities.Neighborhood", "Neighborhood")
                        .WithMany("Drugstores")
                        .HasForeignKey("NeighborhoodId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
