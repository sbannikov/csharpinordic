﻿// <auto-generated />
using System;
using Calculator.Common.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Calculator.Common.Migrations
{
    [DbContext(typeof(DB))]
    [Migration("20220604140837_000")]
    partial class _000
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Calculator.Storage.Color", b =>
                {
                    b.Property<byte[]>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("Calculator.Storage.Material", b =>
                {
                    b.Property<byte[]>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("MaterialColorID")
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("ID");

                    b.HasIndex("MaterialColorID");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Calculator.Storage.Material", b =>
                {
                    b.HasOne("Calculator.Storage.Color", "MaterialColor")
                        .WithMany()
                        .HasForeignKey("MaterialColorID");

                    b.Navigation("MaterialColor");
                });
#pragma warning restore 612, 618
        }
    }
}