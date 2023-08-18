﻿// <auto-generated />
using Animal_Shelter_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Animal_Shelter_Api.Migrations
{
    [DbContext(typeof(Animal_Shelter_ApiContext))]
    [Migration("20230818171439_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Animal_Shelter_Api.Models.FuturePet", b =>
                {
                    b.Property<int>("FuturePetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("FuturePetId");

                    b.ToTable("FuturePets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FuturePet");
                });

            modelBuilder.Entity("Animal_Shelter_Api.Models.Cat", b =>
                {
                    b.HasBaseType("Animal_Shelter_Api.Models.FuturePet");

                    b.Property<string>("Breed")
                        .HasColumnType("longtext")
                        .HasColumnName("Cat_Breed");

                    b.Property<string>("Color")
                        .HasColumnType("longtext");

                    b.Property<bool>("FivPositive")
                        .HasColumnType("tinyint(1)");

                    b.HasDiscriminator().HasValue("Cat");

                    b.HasData(
                        new
                        {
                            FuturePetId = 1,
                            Age = 1,
                            Name = "Coco",
                            Breed = "Siamese",
                            Color = "White",
                            FivPositive = false
                        },
                        new
                        {
                            FuturePetId = 2,
                            Age = 3,
                            Name = "Tuffy",
                            Breed = "Ragamuffin",
                            Color = "Chestnut",
                            FivPositive = true
                        },
                        new
                        {
                            FuturePetId = 3,
                            Age = 3,
                            Name = "Fernando",
                            Breed = "Maine Coon",
                            Color = "Grey",
                            FivPositive = false
                        });
                });

            modelBuilder.Entity("Animal_Shelter_Api.Models.Dog", b =>
                {
                    b.HasBaseType("Animal_Shelter_Api.Models.FuturePet");

                    b.Property<string>("Breed")
                        .HasColumnType("longtext");

                    b.Property<string>("CoatColor")
                        .HasColumnType("longtext");

                    b.Property<int>("DogSize")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Dog");

                    b.HasData(
                        new
                        {
                            FuturePetId = 4,
                            Age = 4,
                            Name = "Bing",
                            Breed = "Corgi",
                            CoatColor = "Sable",
                            DogSize = 0
                        },
                        new
                        {
                            FuturePetId = 5,
                            Age = 3,
                            Name = "Mushroom",
                            Breed = "Pug",
                            CoatColor = "Brindle",
                            DogSize = 0
                        },
                        new
                        {
                            FuturePetId = 6,
                            Age = 1,
                            Name = "Felix",
                            Breed = "Great Pyrenees",
                            CoatColor = "Red",
                            DogSize = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
