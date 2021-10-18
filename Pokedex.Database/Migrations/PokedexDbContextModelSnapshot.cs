﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokedex;
using Pokedex.Database.Contexts;

namespace Pokedex.Migrations
{
    [DbContext(typeof(PokedexDbContext))]
    partial class PokedexDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Pokedex.Models.Pokemon", b =>
                {
                    b.Property<int>("nationalDexNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("attack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("defense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("generation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("healthPoints")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("legendary")
                        .HasColumnType("INTEGER");

                    b.Property<int>("spAttack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("spDefense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("speed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("total")
                        .HasColumnType("INTEGER");

                    b.Property<string>("type1typName")
                        .HasColumnType("TEXT");

                    b.Property<string>("type2typName")
                        .HasColumnType("TEXT");

                    b.HasKey("nationalDexNumber", "name");

                    b.HasIndex("type1typName");

                    b.HasIndex("type2typName");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("Pokedex.Models.Type", b =>
                {
                    b.Property<string>("typeName")
                        .HasColumnType("TEXT");

                    b.HasKey("typeName");

                    b.ToTable("Type");

                    b.HasData(
                        new
                        {
                            typName = "Normal"
                        },
                        new
                        {
                            typName = "Fire"
                        },
                        new
                        {
                            typName = "Water"
                        },
                        new
                        {
                            typName = "Grass"
                        },
                        new
                        {
                            typName = "Electric"
                        },
                        new
                        {
                            typName = "Ice"
                        },
                        new
                        {
                            typName = "Fighting"
                        },
                        new
                        {
                            typName = "Poison"
                        },
                        new
                        {
                            typName = "Ground"
                        },
                        new
                        {
                            typName = "Flying"
                        },
                        new
                        {
                            typName = "Psychic"
                        },
                        new
                        {
                            typName = "Bug"
                        },
                        new
                        {
                            typName = "Rock"
                        },
                        new
                        {
                            typName = "Ghost"
                        },
                        new
                        {
                            typName = "Dragon"
                        },
                        new
                        {
                            typName = "Dark"
                        },
                        new
                        {
                            typName = "Steel"
                        },
                        new
                        {
                            typName = "Fairy"
                        });
                });

            modelBuilder.Entity("Pokedex.Models.Pokemon", b =>
                {
                    b.HasOne("Pokedex.Models.Type", "type1")
                        .WithMany()
                        .HasForeignKey("type1typName");

                    b.HasOne("Pokedex.Models.Type", "type2")
                        .WithMany()
                        .HasForeignKey("type2typName");

                    b.Navigation("type1");

                    b.Navigation("type2");
                });
#pragma warning restore 612, 618
        }
    }
}