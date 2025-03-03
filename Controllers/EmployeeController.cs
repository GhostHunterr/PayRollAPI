using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayRollApi.Models;
using PayrollCoreAPI.Models;

namespace PayRollApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployee()
        {
            return await _context.tblEmployee.ToListAsync();
        }

        [HttpGet("{emp_id}")]
        public async Task<ActionResult<Employees>> GetEmployeeDetails(int emp_id)
        {
            var EmployeeDetail = await _context.tblEmployee.FindAsync(emp_id);

            if (EmployeeDetail == null)
            {
                return NotFound();
            }

            return EmployeeDetail;
        }

        [HttpPost]
        public async Task<ActionResult<Employees>> PostEmployeeDetail(Employees EmployeeDetail)
        {
            _context.tblEmployee.Add(EmployeeDetail);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEmployeeDetail", new { emp_id = EmployeeDetail.emp_id }, EmployeeDetail);
        }


        [HttpDelete("{emp_id}")]

        public async Task<ActionResult> DeleteEmployeeDetail(int emp_id)
        {
            var EmployeeDetail = await _context.tblEmployee.FindAsync(emp_id);

            if (EmployeeDetail == null)
            {
                return NotFound();
            }

            _context.tblEmployee.Remove(EmployeeDetail);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        private bool EmloyeeDetailExists(int emp_id)
        {
            return _context.tblEmployee.Any(e => e.emp_id == emp_id);
        }

        [HttpPut("{emp_id}")]

        public async Task<IActionResult> PutEmployeeDetail(int emp_id, Employees EmployeeDetail)
        {
            if (emp_id != EmployeeDetail.emp_id)
            {
                return BadRequest();
            }

            _context.Entry(EmployeeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(EmloyeeDetailExists(emp_id)))
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


    }
}
