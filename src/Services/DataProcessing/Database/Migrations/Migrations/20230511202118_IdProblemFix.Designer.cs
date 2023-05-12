﻿// <auto-generated />
using System;
using DataProcessing.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Migrations.Migrations
{
    [DbContext(typeof(DataProcessingContext))]
    [Migration("20230511202118_IdProblemFix")]
    partial class IdProblemFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("DataProcessing.Domain.Models.LogProcessedModel", b =>
                {
                    b.Property<int>("Id")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Error")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExceptionType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FaultyCodePlacement")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LogMessage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MLType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Warning")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("LogsProcessed", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
