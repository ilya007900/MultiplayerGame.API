﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiplayerGame.Infrastructure.Database;

#nullable disable

namespace MultiplayerGame.Infrastructure.Migrations
{
    [DbContext(typeof(MultiplayerGameDbContext))]
    [Migration("20230810084847_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MultiplayerGame.Domain.Chats.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Chats", "dbo");
                });

            modelBuilder.Entity("MultiplayerGame.Domain.Chats.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("SentDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Messages", "dbo");
                });

            modelBuilder.Entity("MultiplayerGame.Domain.GameRooms.GameRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.HasKey("Id");

                    b.ToTable("GameRooms", "dbo");
                });

            modelBuilder.Entity("MultiplayerGame.Domain.Games.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("_currentTurnPlayerNickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games", "dbo");
                });

            modelBuilder.Entity("MultiplayerGame.Domain.Games.Movement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PlayerNickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MovementsLog", "log");
                });

            modelBuilder.Entity("MultiplayerGame.Domain.Chats.Message", b =>
                {
                    b.HasOne("MultiplayerGame.Domain.Chats.Chat", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatId");
                });

            modelBuilder.Entity("MultiplayerGame.Domain.GameRooms.GameRoom", b =>
                {
                    b.OwnsMany("MultiplayerGame.Domain.SharedKernel.Player", "Players", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Color")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Color");

                            b1.Property<Guid>("GameRoomId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Nickname")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Nickname");

                            b1.HasKey("Id");

                            b1.HasIndex("GameRoomId");

                            b1.ToTable("GameRooms_Players", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("GameRoomId");
                        });

                    b.Navigation("Players");
                });

            modelBuilder.Entity("MultiplayerGame.Domain.Games.Game", b =>
                {
                    b.OwnsOne("MultiplayerGame.Domain.Games.Area", "FieldSize", b1 =>
                        {
                            b1.Property<Guid>("GameId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Height")
                                .HasColumnType("int")
                                .HasColumnName("FieldHeight");

                            b1.Property<int>("Width")
                                .HasColumnType("int")
                                .HasColumnName("FieldWidth");

                            b1.HasKey("GameId");

                            b1.ToTable("Games", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("GameId");
                        });

                    b.OwnsOne("MultiplayerGame.Domain.Games.Area", "GameUnitSize", b1 =>
                        {
                            b1.Property<Guid>("GameId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Height")
                                .HasColumnType("int")
                                .HasColumnName("GameUnitHeight");

                            b1.Property<int>("Width")
                                .HasColumnType("int")
                                .HasColumnName("GameUnitWidth");

                            b1.HasKey("GameId");

                            b1.ToTable("Games", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("GameId");
                        });

                    b.OwnsMany("MultiplayerGame.Domain.Games.GameUnit", "GameUnits", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("GameId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("GameId");

                            b1.ToTable("GameUnit", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("GameId");

                            b1.OwnsOne("MultiplayerGame.Domain.SharedKernel.Player", "Player", b2 =>
                                {
                                    b2.Property<int>("GameUnitId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Color")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("PlayerColor");

                                    b2.Property<string>("Nickname")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("PlayerNickname");

                                    b2.HasKey("GameUnitId");

                                    b2.ToTable("GameUnit", "dbo");

                                    b2.WithOwner()
                                        .HasForeignKey("GameUnitId");
                                });

                            b1.OwnsOne("MultiplayerGame.Domain.Games.Position", "Position", b2 =>
                                {
                                    b2.Property<int>("GameUnitId")
                                        .HasColumnType("int");

                                    b2.Property<int>("X")
                                        .HasColumnType("int")
                                        .HasColumnName("PositionX");

                                    b2.Property<int>("Y")
                                        .HasColumnType("int")
                                        .HasColumnName("PositionY");

                                    b2.HasKey("GameUnitId");

                                    b2.ToTable("GameUnit", "dbo");

                                    b2.WithOwner()
                                        .HasForeignKey("GameUnitId");
                                });

                            b1.Navigation("Player")
                                .IsRequired();

                            b1.Navigation("Position")
                                .IsRequired();
                        });

                    b.Navigation("FieldSize")
                        .IsRequired();

                    b.Navigation("GameUnitSize")
                        .IsRequired();

                    b.Navigation("GameUnits");
                });

            modelBuilder.Entity("MultiplayerGame.Domain.Games.Movement", b =>
                {
                    b.OwnsOne("MultiplayerGame.Domain.Games.Position", "NewPosition", b1 =>
                        {
                            b1.Property<int>("MovementId")
                                .HasColumnType("int");

                            b1.Property<int>("X")
                                .HasColumnType("int")
                                .HasColumnName("NewXPosition");

                            b1.Property<int>("Y")
                                .HasColumnType("int")
                                .HasColumnName("NewYPosition");

                            b1.HasKey("MovementId");

                            b1.ToTable("MovementsLog", "log");

                            b1.WithOwner()
                                .HasForeignKey("MovementId");
                        });

                    b.OwnsOne("MultiplayerGame.Domain.Games.Position", "OldPosition", b1 =>
                        {
                            b1.Property<int>("MovementId")
                                .HasColumnType("int");

                            b1.Property<int>("X")
                                .HasColumnType("int")
                                .HasColumnName("OldXPosition");

                            b1.Property<int>("Y")
                                .HasColumnType("int")
                                .HasColumnName("OldYPosition");

                            b1.HasKey("MovementId");

                            b1.ToTable("MovementsLog", "log");

                            b1.WithOwner()
                                .HasForeignKey("MovementId");
                        });

                    b.Navigation("NewPosition")
                        .IsRequired();

                    b.Navigation("OldPosition")
                        .IsRequired();
                });

            modelBuilder.Entity("MultiplayerGame.Domain.Chats.Chat", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
