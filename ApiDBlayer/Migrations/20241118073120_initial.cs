using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiDBlayer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "User_Infos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Infos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users_credentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_credentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Driver = table.Column<bool>(type: "bit", nullable: false),
                    UserCredentialsId = table.Column<int>(type: "int", nullable: false),
                    UserInfoId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TruckTypeId = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_User_Infos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "User_Infos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_credentials_UserCredentialsId",
                        column: x => x.UserCredentialsId,
                        principalTable: "Users_credentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "TruckTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Trucktype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtoUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TruckType_Users_DtoUserId",
                        column: x => x.DtoUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    TruckTypeId = table.Column<int>(type: "int", nullable: true),
                    DtoUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_TruckTypes_TruckTypeId",
                        column: x => x.TruckTypeId,
                        principalTable: "TruckTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_DtoUserId",
                        column: x => x.DtoUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ratings = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    DtoUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Users_DtoUserId",
                        column: x => x.DtoUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rating_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rating_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "TruckTypes",
                columns: new[] { "Id", "Trucktype" },
                values: new object[,]
                {
                    { 1, "Lastbil" },
                    { 2, "Varebil" }
                });

            migrationBuilder.InsertData(
                table: "User_Infos",
                columns: new[] { "Id", "Address", "Email", "Name", "Phone_number" },
                values: new object[,]
                {
                    { 1, "Viborg", "simon@gmail.com", "Simon", 88888888 },
                    { 2, "Fjelstervang", "marcus@gmail.com", "Marcus", 12345678 }
                });

            migrationBuilder.InsertData(
                table: "Users_credentials",
                columns: new[] { "Id", "Password" },
                values: new object[,]
                {
                    { 1, "$2a$12$F4AMp7JgfE05JlEhpkNZc./kr1LiR27Pm28O4M8mR9QrASYYnb1XO" },
                    { 2, "$2a$12$JaBadjoD5fqhKjI.Algi7.fAGmMxVdgzGOAWn8imtJ9E9m6dgcbBa" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Driver", "OrderId", "RatingId", "TruckTypeId", "UserCredentialsId", "UserInfoId" },
                values: new object[,]
                {
                    { 1, true, 0, 0, 1, 1, 1 },
                    { 2, false, 0, 0, 0, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DriverId",
                table: "Orders",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DtoUserId",
                table: "Orders",
                column: "DtoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OwnerId",
                table: "Orders",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TruckTypeId",
                table: "Orders",
                column: "TruckTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_DtoUserId",
                table: "Rating",
                column: "DtoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ReceiverId",
                table: "Rating",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_SenderId",
                table: "Rating",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TruckTypeId",
                table: "Users",
                column: "TruckTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCredentialsId",
                table: "Users",
                column: "UserCredentialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserInfoId",
                table: "Users",
                column: "UserInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TruckTypes");

            migrationBuilder.DropTable(
                name: "User_Infos");

            migrationBuilder.DropTable(
                name: "Users_credentials");
        }
    }
}
