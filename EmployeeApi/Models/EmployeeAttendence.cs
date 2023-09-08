using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApi.Models
{
    public class EmployeeAttendence
    {
        [ForeignKey("employeeId")]
        public int employeeId { get; set; }
        
      
        public DateTime attendanceDate { get; set; }
        public bool isPresent { get; set; }
        public bool isAbsent { get; set; }
        public bool isOffday { get; set; }
       

       // public Employee Employee { get; set; }
    }

   
}
