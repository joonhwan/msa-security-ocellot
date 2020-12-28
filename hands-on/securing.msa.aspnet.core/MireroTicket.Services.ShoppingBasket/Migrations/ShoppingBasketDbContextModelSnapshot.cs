﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MireroTicket.Services.ShoppingBasket.DbContexts;

namespace MireroTicket.Services.ShoppingBasket.Migrations
{
    [DbContext(typeof(ShoppingBasketDbContext))]
    partial class ShoppingBasketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("MireroTicket.Services.ShoppingBasket.Entities.Basket", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("MireroTicket.Services.ShoppingBasket.Entities.BasketChangeEvent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("BasetChangeType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<string>("InsertedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BasketChangeEvents");
                });

            modelBuilder.Entity("MireroTicket.Services.ShoppingBasket.Entities.BasketLine", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("BasketId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EventId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TicketAmount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("EventId");

                    b.ToTable("BasketLines");
                });

            modelBuilder.Entity("MireroTicket.Services.ShoppingBasket.Entities.Event", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = "ee272f8b-6096-4cb6-8625-bb4bb2d89e8b",
                            Date = "2021-06-28T14:41:52.6504580+09:00",
                            Name = "John Egbert Live"
                        },
                        new
                        {
                            Id = "3448d5a4-0f72-4dd7-bf15-c14a46b26c00",
                            Date = "2021-09-28T14:41:52.6539740+09:00",
                            Name = "The State of Affairs: Michael Live!"
                        },
                        new
                        {
                            Id = "b419a7ca-3321-4f38-be8e-4d7b6a529319",
                            Date = "2021-04-28T14:41:52.6539810+09:00",
                            Name = "Clash of the DJs"
                        },
                        new
                        {
                            Id = "62787623-4c52-43fe-b0c9-b7044fb5929b",
                            Date = "2021-04-28T14:41:52.6539830+09:00",
                            Name = "Spanish guitar hits with Manuel"
                        },
                        new
                        {
                            Id = "1babd057-e980-4cb3-9cd2-7fdd9e525668",
                            Date = "2021-10-28T14:41:52.6539920+09:00",
                            Name = "Techorama 2021"
                        },
                        new
                        {
                            Id = "adc42c09-08c1-4d2c-9f96-2d15bb1af299",
                            Date = "2021-08-28T14:41:52.6539930+09:00",
                            Name = "To the Moon and Back"
                        });
                });

            modelBuilder.Entity("MireroTicket.Services.ShoppingBasket.Entities.BasketLine", b =>
                {
                    b.HasOne("MireroTicket.Services.ShoppingBasket.Entities.Basket", "Basket")
                        .WithMany("Lines")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MireroTicket.Services.ShoppingBasket.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
