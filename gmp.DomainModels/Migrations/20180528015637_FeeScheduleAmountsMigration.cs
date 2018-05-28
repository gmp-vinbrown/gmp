using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Migrations
{
    public partial class FeeScheduleAmountsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "FeeSchedule");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "FeeSchedule",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "FeeSchedule",
                type: "decimal(5, 2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercent",
                table: "FeeSchedule",
                type: "decimal(5, 2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "FeeSchedule");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "FeeSchedule");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "FeeSchedule");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "FeeSchedule",
                type: "decimal(5, 2)",
                nullable: false,
                defaultValueSql: "((0))");
        }
    }
}
