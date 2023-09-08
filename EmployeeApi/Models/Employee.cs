using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApi.Models
{
    [PrimaryKey(nameof(employeeId), nameof(employeeCode))]
    public class Employee
    {
        

        public int employeeId { get; set; }
        [Required]
        public string employeeName { get; set; }
        
        public string employeeCode { get; set; }
        public int employeeSalary { get; set; }
        [Required]
        public int supervisorId { get; set; }
        

        //  public List<EmployeeAttendence> EmployeeAttendences { get; set; }

    }
}
