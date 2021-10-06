﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectAnimalCatalog.Data;

namespace ProjectAnimalCatalog.Migrations
{
    [DbContext(typeof(ASPNETCOREPROJECTContext))]
    partial class ASPNETCOREPROJECTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Hebrew_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectAnimalCatalog.Models.Animal", b =>
                {
                    b.Property<int>("AnimalsId")
                        .HasColumnType("int")
                        .HasColumnName("AnimalsID");

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PictureName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("AnimalsId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            AnimalsId = 1,
                            Age = (byte)69,
                            CategoryId = 1,
                            Description = "a large, mostly herbivorous, semiaquatic mammal",
                            Name = "Hipo",
                            PictureName = "Hipo.jpg"
                        },
                        new
                        {
                            AnimalsId = 2,
                            Age = (byte)87,
                            CategoryId = 3,
                            Description = "Snakes are elongated, limbless",
                            Name = "Snake",
                            PictureName = "Snake-Pit-Vipet.jpg"
                        },
                        new
                        {
                            AnimalsId = 3,
                            Age = (byte)51,
                            CategoryId = 1,
                            Description = " is a domesticated descendant of the wolf",
                            Name = "Dog",
                            PictureName = "Dog.jpg"
                        },
                        new
                        {
                            AnimalsId = 4,
                            Age = (byte)32,
                            CategoryId = 1,
                            Description = "a domestic species of small carnivorous mammal",
                            Name = "Cat",
                            PictureName = "Cat.jpg"
                        },
                        new
                        {
                            AnimalsId = 5,
                            Age = (byte)44,
                            CategoryId = 4,
                            Description = "Sharks are a group of elasmobranch fish",
                            Name = "Shark",
                            PictureName = "Shark.jpg"
                        },
                        new
                        {
                            AnimalsId = 6,
                            Age = (byte)72,
                            CategoryId = 1,
                            Description = "aquatic mammals within the infraorder Cetacea",
                            Name = "Dolphin",
                            PictureName = "Dolphin.jpg"
                        },
                        new
                        {
                            AnimalsId = 7,
                            Age = (byte)11,
                            CategoryId = 1,
                            Description = "aquatic mammals within the infraorder Cetacea",
                            Name = "Lion",
                            PictureName = "Lion.jpg"
                        },
                        new
                        {
                            AnimalsId = 8,
                            Age = (byte)39,
                            CategoryId = 3,
                            Description = "A frog is any member of a diverse",
                            Name = "Frog",
                            PictureName = "Frog.png"
                        },
                        new
                        {
                            AnimalsId = 9,
                            Age = (byte)8,
                            CategoryId = 4,
                            Description = "Shrimp are decapod crustaceans",
                            Name = "Shrimp",
                            PictureName = "Shrimp.jpg"
                        },
                        new
                        {
                            AnimalsId = 10,
                            Age = (byte)2,
                            CategoryId = 5,
                            Description = "Lizards are a widespread group of ",
                            Name = "Lizard",
                            PictureName = "Lizard.jpg"
                        });
                });

            modelBuilder.Entity("ProjectAnimalCatalog.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength(true);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "mammals"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "birds"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "adm"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "fishes"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "reptiles"
                        });
                });

            modelBuilder.Entity("ProjectAnimalCatalog.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .HasColumnType("int")
                        .HasColumnName("CommentID");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int")
                        .HasColumnName("AnimalID");

                    b.Property<string>("Comment1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Comment");

                    b.HasKey("CommentId");

                    b.HasIndex("AnimalId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            AnimalId = 1,
                            Comment1 = "Wonderful"
                        },
                        new
                        {
                            CommentId = 2,
                            AnimalId = 1,
                            Comment1 = "Wonderful"
                        },
                        new
                        {
                            CommentId = 3,
                            AnimalId = 2,
                            Comment1 = "Wonderful"
                        },
                        new
                        {
                            CommentId = 4,
                            AnimalId = 2,
                            Comment1 = "Wonderful"
                        },
                        new
                        {
                            CommentId = 5,
                            AnimalId = 3,
                            Comment1 = "Wonderful"
                        },
                        new
                        {
                            CommentId = 6,
                            AnimalId = 1,
                            Comment1 = "Wonderful"
                        },
                        new
                        {
                            CommentId = 7,
                            AnimalId = 3,
                            Comment1 = "Wonderful"
                        },
                        new
                        {
                            CommentId = 8,
                            AnimalId = 3,
                            Comment1 = "Wonderful"
                        });
                });

            modelBuilder.Entity("ProjectAnimalCatalog.Models.Animal", b =>
                {
                    b.HasOne("ProjectAnimalCatalog.Models.Category", "Category")
                        .WithMany("Animals")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Animals_Categories")
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProjectAnimalCatalog.Models.Comment", b =>
                {
                    b.HasOne("ProjectAnimalCatalog.Models.Animal", "Animal")
                        .WithMany("Comments")
                        .HasForeignKey("AnimalId")
                        .HasConstraintName("FK_Comments_Animals")
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("ProjectAnimalCatalog.Models.Animal", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ProjectAnimalCatalog.Models.Category", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}