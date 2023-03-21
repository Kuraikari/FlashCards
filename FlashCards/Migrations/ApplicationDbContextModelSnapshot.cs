﻿// <auto-generated />
using FlashCards.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlashCards.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("FlashCards.Models.FlashCards.FlashCardModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BackId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FrontId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubTopics")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Topics")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BackId");

                    b.HasIndex("FrontId");

                    b.ToTable("FlashCards");
                });

            modelBuilder.Entity("FlashCards.Models.FlashCards.FlashCardSideModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BackgroundColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FlashCardSides");
                });

            modelBuilder.Entity("FlashCards.Models.FlashCards.FlashCardModel", b =>
                {
                    b.HasOne("FlashCards.Models.FlashCards.FlashCardSideModel", "Back")
                        .WithMany()
                        .HasForeignKey("BackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlashCards.Models.FlashCards.FlashCardSideModel", "Front")
                        .WithMany()
                        .HasForeignKey("FrontId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Back");

                    b.Navigation("Front");
                });
#pragma warning restore 612, 618
        }
    }
}
