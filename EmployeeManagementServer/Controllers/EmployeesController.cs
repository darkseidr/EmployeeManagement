using EmployeeManagement.Data;
using EmployeeManagement.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementServer.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {

        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpPost("addEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee( Employee employee)
        {
            try
            {
                employee.Id = 0;
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding employee: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("getEmployeeList")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
        [Authorize]
        [HttpGet("getEmployeeDetails/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }
        [Authorize]
        [HttpPost("updateEmployeeDetails")]
        public async Task<ActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            if (!_context.Employees.Any(e => e.Id == employee.Id))
            {
                return NotFound();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [Authorize]
        [HttpDelete("deleteEmployeeDetails/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //[Authorize]
        //[HttpPost("updateEmpStatus/{id}")]
        //public async Task<IActionResult> UpdateEmployeeStatus(int id, [FromBody] bool isActive)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    employee.IsActive = isActive;
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
