﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Medifii.PharmacyService.Persistence.Migrations
{
    [DbContext(typeof(PharmacyContext))]
    partial class PharmacyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Medifii.PharmacyService.Data.Entities.Pharmacy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("Medifii.PharmacyService.Data.Entities.Pharmacy", b =>
                {
                    b.OwnsOne("Medifii.PharmacyService.Data.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("PharmacyId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PharmacyId");

                            b1.ToTable("Pharmacies");

                            b1.WithOwner()
                                .HasForeignKey("PharmacyId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
