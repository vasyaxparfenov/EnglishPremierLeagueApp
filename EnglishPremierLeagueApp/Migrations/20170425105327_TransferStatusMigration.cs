using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishPremierLeagueApp.Migrations
{
    public partial class TransferStatusMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable("Transfers");
            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fee = table.Column<decimal>(name: " Fee ", type: "money", nullable: false),
                    FromId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(name: " Status ", type: "int", nullable: false),
                    ToId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                });
            migrationBuilder.CreateIndex(
                name: "IX_Transfers_FromId",
                table: "Transfers",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_PlayerId",
                table: "Transfers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_ToId",
                table: "Transfers",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                 name: "FK_Transfers_ToTable_Teams_To",
                 table: "Transfers",
                 column: "FromId",
                 principalTable: "Teams",
                 principalColumn: "Id",
                 onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_ToTable_Teams_From",
                table: "Transfers",
                column: "ToId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_ToTable_Players",
                table: "Transfers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Transfers");
        }
        
    }
}
