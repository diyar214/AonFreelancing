﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AonFreelancing.Migrations
{
    /// <inheritdoc />
    public partial class BidMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: false),
                    FreelancerId = table.Column<long>(type: "INTEGER", nullable: false),
                    ProposedPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "pending"),
                    SubmittedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ClientEntityId = table.Column<long>(type: "INTEGER", nullable: true),
                    SystemUserEntityId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Clients_ClientEntityId",
                        column: x => x.ClientEntityId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bids_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_SystemUsers_SystemUserEntityId",
                        column: x => x.SystemUserEntityId,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ClientEntityId",
                table: "Bids",
                column: "ClientEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_FreelancerId",
                table: "Bids",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ProjectId",
                table: "Bids",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_SystemUserEntityId",
                table: "Bids",
                column: "SystemUserEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");
        }
    }
}
