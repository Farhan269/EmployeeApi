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
    public class EmployeeAttendenceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeAttendenceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeAttendence>> Get()
            => await _context.EmployeeAttendences.ToListAsync();


    }
}
