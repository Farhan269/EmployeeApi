using EmployeeApi.Data;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()

            => await _context.Employees.ToListAsync();

        //Update an employee’s Employee Name and Code [Don't allow duplicate employee code]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {


            if (id != employee.employeeId) return BadRequest();

            if (await _context.Employees.AnyAsync(e => e.employeeId != id && e.employeeCode == employee.employeeCode))
            {
                return BadRequest("EmployeeCode already exists.");
            }

            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Get employee who has 3rd highest salary
        [HttpGet("thirdhighestsalary")]
        public async Task<ActionResult<Employee>> GetEmployeeWithThirdHighestSalary()
        {
            var thirdHighestSalaryEmployee = await _context.Employees
                .OrderByDescending(e => e.employeeSalary)
                .Skip(2) // Skip the top 2 employees with the highest salaries
                .Take(1) // Take the next employee, which will be the 3rd highest
                .FirstOrDefaultAsync();

            if (thirdHighestSalaryEmployee == null)
            {
                return NotFound();
            }

            return Ok(thirdHighestSalaryEmployee);
        }

        //Get all employee based on maximum to minimum salary who has not any absent record
        [HttpGet("employees-without-absences")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesWithoutAbsences()
        {
            var employeesWithoutAbsences = await _context.Employees
                .Where(e => !_context.EmployeeAttendences.Any(a => a.employeeId == e.employeeId && (a.isPresent || a.isOffday)))
                .OrderByDescending(e => e.employeeSalary)
                .ToListAsync();

            if (employeesWithoutAbsences == null || employeesWithoutAbsences.Count == 0)
            {
                return NotFound();
            }

            return Ok(employeesWithoutAbsences);
        }


        //Get monthly attendance report of all employee
        [HttpGet("monthly-attendance-report")]
        public async Task<ActionResult<IEnumerable<MonthlyAttendanceReport>>> GetMonthlyAttendanceReport(int month, int year)
        {
            var reportData = await _context.Employees
                .Join(
                    _context.EmployeeAttendences
                        .Where(a => a.attendanceDate.Month == month && a.attendanceDate.Year == year),
                    employee => employee.employeeId,
                    attendance => attendance.employeeId,
                    (employee, attendance) => new MonthlyAttendanceReport
                    {
                        EmployeeName = employee.employeeName,
                        MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),
                        PayableSalary = CalculatePayableSalary(employee, attendance),
                        TotalPresent = attendance.isPresent ? 1 : 0,
                        TotalAbsent = attendance.isAbsent ? 1 : 0,
                        TotalOffday = attendance.isOffday ? 1 : 0
                    })
                .ToListAsync();

            return Ok(reportData);
        }

        private decimal CalculatePayableSalary(Employee employee, EmployeeAttendence attendance)
        {
            // Calculate base salary for the employee
            decimal baseSalary = employee.employeeSalary;

            // Calculate the deduction (2% of base salary for each absent day)
            decimal deduction = baseSalary * (0.02m * (attendance.isAbsent ? 1 : 0));

            // Calculate the payable salary
            decimal payableSalary = baseSalary - deduction;

            return payableSalary;
        }

        //Get a hierarchy from an employee based on his supervisor.
        [HttpGet("employee-hierarchy/{employeeId}")]
        public async Task<IActionResult> GetEmployeeHierarchy(int employeeId)
        {
            var hierarchy = new List<string>();
            var employee = await _context.Employees.FindAsync(employeeId);

            while (employee != null)
            {
                hierarchy.Insert(0, employee.employeeName); // Insert at the beginning to maintain order
                employee = await _context.Employees.FindAsync(employee.supervisorId);
            }

            if (hierarchy.Count == 0)
            {
                return NotFound();
            }

            return Ok(hierarchy);
        }


    }

}


