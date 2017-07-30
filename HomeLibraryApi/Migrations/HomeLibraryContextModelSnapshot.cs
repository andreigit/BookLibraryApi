﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HomeLibraryApi.Models;

namespace HomeLibraryApi.Migrations
{
    [DbContext(typeof(HomeLibraryContext))]
    partial class HomeLibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeLibraryApi.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("WorkId");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("VolumeCount");

                    b.HasKey("Id");

                    b.ToTable("Editions");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("WorkId");

                    b.Property<int?>("WorkId1");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.HasIndex("WorkId1");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Volume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EditionId");

                    b.Property<int?>("PageCount");

                    b.Property<int?>("YearOfPublication");

                    b.HasKey("Id");

                    b.HasIndex("EditionId");

                    b.ToTable("Volumes");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.VolumeExemplar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InventoryNumber");

                    b.Property<bool?>("IsInPlace");

                    b.Property<decimal?>("Price");

                    b.Property<int?>("VolumeId");

                    b.Property<int?>("YearOfPurchase");

                    b.HasKey("Id");

                    b.HasIndex("VolumeId");

                    b.ToTable("VolumeExemplars");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AltGenreId");

                    b.Property<int?>("AltWorkKindId");

                    b.Property<string>("Description");

                    b.Property<int?>("GenreId");

                    b.Property<string>("Name");

                    b.Property<int?>("VolumeId");

                    b.Property<int?>("WorkKindId");

                    b.Property<int?>("YearOfCompletion");

                    b.Property<int?>("YearOfFirstPublication");

                    b.HasKey("Id");

                    b.HasIndex("AltWorkKindId");

                    b.HasIndex("VolumeId");

                    b.HasIndex("WorkKindId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.WorkKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("WorkKinds");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Author", b =>
                {
                    b.HasOne("HomeLibraryApi.Models.Work")
                        .WithMany("Authors")
                        .HasForeignKey("WorkId");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Genre", b =>
                {
                    b.HasOne("HomeLibraryApi.Models.Work")
                        .WithMany("AltGenres")
                        .HasForeignKey("WorkId");

                    b.HasOne("HomeLibraryApi.Models.Work")
                        .WithMany("Genres")
                        .HasForeignKey("WorkId1");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Volume", b =>
                {
                    b.HasOne("HomeLibraryApi.Models.Edition")
                        .WithMany("Volumes")
                        .HasForeignKey("EditionId");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.VolumeExemplar", b =>
                {
                    b.HasOne("HomeLibraryApi.Models.Volume", "Volume")
                        .WithMany()
                        .HasForeignKey("VolumeId");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Work", b =>
                {
                    b.HasOne("HomeLibraryApi.Models.WorkKind", "AltWorkKind")
                        .WithMany()
                        .HasForeignKey("AltWorkKindId");

                    b.HasOne("HomeLibraryApi.Models.Volume")
                        .WithMany("Works")
                        .HasForeignKey("VolumeId");

                    b.HasOne("HomeLibraryApi.Models.WorkKind", "WorkKind")
                        .WithMany()
                        .HasForeignKey("WorkKindId");
                });
        }
    }
}
