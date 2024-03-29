﻿// <auto-generated />
using System;
using AgenciaFull.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgenciaFull.Migrations
{
    [DbContext(typeof(AgenciaFullContext))]
    [Migration("20240218192115_AgenciaFull")]
    partial class AgenciaFull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgenciaFull.Models.Hospedagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Destino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Entrada")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hoteis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quarto")
                        .HasColumnType("int");

                    b.Property<DateTime>("Saida")
                        .HasColumnType("datetime2");

                    b.Property<int>("Viajantes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hospedagem");
                });
#pragma warning restore 612, 618
        }
    }
}
