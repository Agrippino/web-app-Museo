﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web_app_Museo.Data;

#nullable disable

namespace web_app_Museo.Migrations
{
    [DbContext(typeof(MuseoContext))]
    [Migration("20220531152820_QuantitaAggiuntaMigration")]
    partial class QuantitaAggiuntaMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("web_app_Museo.Models.Acquisto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProdottoId")
                        .HasColumnType("int");

                    b.Property<int>("QuantitaDaAcquistare")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdottoId");

                    b.ToTable("Acquisti");
                });

            modelBuilder.Entity("web_app_Museo.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("web_app_Museo.Models.Prodotto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("Text");

                    b.Property<string>("Immagine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.Property<int>("QuantitaDisponibile")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Prodotti");
                });

            modelBuilder.Entity("web_app_Museo.Models.QuantitaAggiunta", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Totale")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToView("QuantitaAggiunte");
                });

            modelBuilder.Entity("web_app_Museo.Models.Rifornimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataRifornimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeFornitore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProdottoId")
                        .HasColumnType("int");

                    b.Property<int>("QuantitaDaAggiungere")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdottoId");

                    b.ToTable("Rifornimenti");
                });

            modelBuilder.Entity("web_app_Museo.Models.Acquisto", b =>
                {
                    b.HasOne("web_app_Museo.Models.Prodotto", "Prodotti")
                        .WithMany("Acquisti")
                        .HasForeignKey("ProdottoId");

                    b.Navigation("Prodotti");
                });

            modelBuilder.Entity("web_app_Museo.Models.Prodotto", b =>
                {
                    b.HasOne("web_app_Museo.Models.Categoria", "Categorie")
                        .WithMany("Prodotti")
                        .HasForeignKey("CategoriaId");

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("web_app_Museo.Models.Rifornimento", b =>
                {
                    b.HasOne("web_app_Museo.Models.Prodotto", "Prodotto")
                        .WithMany("Rifornimenti")
                        .HasForeignKey("ProdottoId");

                    b.Navigation("Prodotto");
                });

            modelBuilder.Entity("web_app_Museo.Models.Categoria", b =>
                {
                    b.Navigation("Prodotti");
                });

            modelBuilder.Entity("web_app_Museo.Models.Prodotto", b =>
                {
                    b.Navigation("Acquisti");

                    b.Navigation("Rifornimenti");
                });
#pragma warning restore 612, 618
        }
    }
}
