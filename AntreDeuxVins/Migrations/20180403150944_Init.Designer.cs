﻿// <auto-generated />
using AntreDeuxVins.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AntreDeuxVins.Migrations
{
    [DbContext(typeof(AntreDeuxVinsDbContext))]
    [Migration("20180403150944_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AntreDeuxVinsModel.Aliment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Aliments");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.Cave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Nom");

                    b.Property<int?>("UtilisateurId");

                    b.HasKey("Id");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Caves");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.CaveVin", b =>
                {
                    b.Property<int>("CaveId");

                    b.Property<int>("VinId");

                    b.Property<int>("Quantite");

                    b.HasKey("CaveId", "VinId");

                    b.HasIndex("VinId");

                    b.ToTable("CaveVins");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.Couleur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Couleurs");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.Pays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Pays");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.Property<int?>("PaysId");

                    b.HasKey("Id");

                    b.HasIndex("PaysId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Mail");

                    b.Property<string>("Nom");

                    b.Property<string>("Password");

                    b.Property<string>("Prenom");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.Vin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CouleurId");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<DateTime>("Millesime");

                    b.Property<string>("Nom");

                    b.Property<int?>("PaysId");

                    b.Property<int?>("RegionId");

                    b.Property<string>("Type");

                    b.Property<int>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("CouleurId");

                    b.HasIndex("PaysId");

                    b.HasIndex("RegionId");

                    b.ToTable("Vins");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.VinAliment", b =>
                {
                    b.Property<int>("VinId");

                    b.Property<int>("AlimentId");

                    b.HasKey("VinId", "AlimentId");

                    b.HasIndex("AlimentId");

                    b.ToTable("VinAliment");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.Cave", b =>
                {
                    b.HasOne("AntreDeuxVinsModel.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.CaveVin", b =>
                {
                    b.HasOne("AntreDeuxVinsModel.Cave", "Cave")
                        .WithMany("CaveVins")
                        .HasForeignKey("CaveId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AntreDeuxVinsModel.Vin", "Vin")
                        .WithMany("VinCaves")
                        .HasForeignKey("VinId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AntreDeuxVinsModel.Region", b =>
                {
                    b.HasOne("AntreDeuxVinsModel.Pays", "Pays")
                        .WithMany("Regions")
                        .HasForeignKey("PaysId");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.Utilisateur", b =>
                {
                    b.HasOne("AntreDeuxVinsModel.Role", "Role")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.Vin", b =>
                {
                    b.HasOne("AntreDeuxVinsModel.Couleur", "Couleur")
                        .WithMany("Vins")
                        .HasForeignKey("CouleurId");

                    b.HasOne("AntreDeuxVinsModel.Pays", "Pays")
                        .WithMany()
                        .HasForeignKey("PaysId");

                    b.HasOne("AntreDeuxVinsModel.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("AntreDeuxVinsModel.VinAliment", b =>
                {
                    b.HasOne("AntreDeuxVinsModel.Aliment", "Aliment")
                        .WithMany("AlimentVins")
                        .HasForeignKey("AlimentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AntreDeuxVinsModel.Vin", "Vin")
                        .WithMany("VinAliments")
                        .HasForeignKey("VinId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
