using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiplayerGame.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "log");

            migrationBuilder.CreateTable(
                name: "Chats",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameRooms",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldWidth = table.Column<int>(type: "int", nullable: false),
                    FieldHeight = table.Column<int>(type: "int", nullable: false),
                    GameUnitWidth = table.Column<int>(type: "int", nullable: false),
                    GameUnitHeight = table.Column<int>(type: "int", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    _currentTurnPlayerNickname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovementsLog",
                schema: "log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerNickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldXPosition = table.Column<int>(type: "int", nullable: false),
                    OldYPosition = table.Column<int>(type: "int", nullable: false),
                    NewXPosition = table.Column<int>(type: "int", nullable: false),
                    NewYPosition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementsLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "Chats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameRooms_Players",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRooms_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRooms_Players_GameRooms_GameRoomId",
                        column: x => x.GameRoomId,
                        principalSchema: "dbo",
                        principalTable: "GameRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameUnit",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerNickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionY = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameUnit_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "dbo",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameRooms_Players_GameRoomId",
                schema: "dbo",
                table: "GameRooms_Players",
                column: "GameRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUnit_GameId",
                schema: "dbo",
                table: "GameUnit",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                schema: "dbo",
                table: "Messages",
                column: "ChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRooms_Players",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GameUnit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MovementsLog",
                schema: "log");

            migrationBuilder.DropTable(
                name: "GameRooms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Chats",
                schema: "dbo");
        }
    }
}
