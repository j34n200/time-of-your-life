﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using time_of_your_life.Data;

#nullable disable

namespace time_of_your_life.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("time_of_your_life.Models.ClockProps", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("BlinkColons")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClockFontColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClockFontSize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FontColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FontFamily")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TitleFontSize")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ClockProps");
                });
#pragma warning restore 612, 618
        }
    }
}
