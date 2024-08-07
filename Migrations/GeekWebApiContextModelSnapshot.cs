﻿// <auto-generated />
using System;
using GeekWebAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeekWebAPI.Migrations
{
    [DbContext(typeof(GeekWebApiContext))]
    partial class GeekWebApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("GeekWebAPI.Models.Anime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Temporadas")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("GeekWebAPI.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("TEXT");

                    b.Property<float>("DuracaoMinutos")
                        .HasColumnType("REAL");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("GeekWebAPI.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Paginas")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("GeekWebAPI.Models.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Temporadas")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });
#pragma warning restore 612, 618
        }
    }
}
