using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAttendences_Employees_employeeId1_employeeCode",
                table: "EmployeeAttendences");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAttendences_employeeId1_employeeCode",
                table: "EmployeeAttendences");

            migrationBuilder.DropColumn(
                name: "employeeCode",
                table: "EmployeeAttendences");

            migrationBuilder.DropColumn(
                name: "employeeId1",
                table: "EmployeeAttendences");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "employeeCode",
                table: "EmployeeAttendences",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "employeeId1",
                table: "EmployeeAttendences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendences_employeeId1_employeeCode",
                table: "EmployeeAttendences",
                columns: new[] { "employeeId1", "employeeCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAttendences_Employees_employeeId1_employeeCode",
                table: "EmployeeAttendences",
                columns: new[] { "employeeId1", "employeeCode" },
                principalTable: "Employees",
                principalColumns: new[] { "employeeId", "employeeCode" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
