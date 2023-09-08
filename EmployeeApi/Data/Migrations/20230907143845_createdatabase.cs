using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class createdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    employeeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    employeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeSalary = table.Column<int>(type: "int", nullable: false),
                    supervisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => new { x.employeeId, x.employeeCode });
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendences",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    employeeId1 = table.Column<int>(type: "int", nullable: false),
                    employeeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    attendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isPresent = table.Column<bool>(type: "bit", nullable: false),
                    isAbsent = table.Column<bool>(type: "bit", nullable: false),
                    isOffday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_EmployeeAttendences_Employees_employeeId1_employeeCode",
                        columns: x => new { x.employeeId1, x.employeeCode },
                        principalTable: "Employees",
                        principalColumns: new[] { "employeeId", "employeeCode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendences_employeeId1_employeeCode",
                table: "EmployeeAttendences",
                columns: new[] { "employeeId1", "employeeCode" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAttendences");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
