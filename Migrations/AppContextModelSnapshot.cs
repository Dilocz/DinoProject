﻿// <auto-generated />
using System;
using Context = DinoProject.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DinoProject.Migrations
{
    [DbContext(typeof(Context.AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("DinoProject.Models.Dino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WhenId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WhenId");

                    b.ToTable("Dinos");
                });

            modelBuilder.Entity("DinoProject.Models.When", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("When");
                });

            modelBuilder.Entity("DinoProject.Models.Dino", b =>
                {
                    b.HasOne("DinoProject.Models.When", "When")
                        .WithMany()
                        .HasForeignKey("WhenId");

                    b.Navigation("When");
                });
#pragma warning restore 612, 618
        }
    }
}
