using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PayRollApi.Models;
using PayRollApi.BLogic;

namespace PayRollApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly DataContext _context;
        public PayController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Salary> Get()
        {
            List<Salary> mysalary = new List<Salary>();
            var payvalues = _context.tblEmployee.ToList();
       
            foreach ( var sal in payvalues)
            {              
                mysalary.Add(new Salary { emp_id = sal.emp_id, emp_name = sal.emp_name,
                finalvalue = BLogic.BLogic.FinalSalary(sal.emp_id,sal.emp_name,Convert.ToInt32(sal.noOfDependants),
                sal.emp_gender,Convert.ToDouble(sal.itex),Convert.ToDouble(sal.ei),Convert.ToDouble(sal.cpp),
                Convert.ToDouble(sal.additions),Convert.ToDouble(sal.grosssalary)) });              
            }
       
            return mysalary;                    
        }

        // GET api/<PayController>/5
        [HttpGet("{emp_id}")]
        public string Get(int emp_id)
        {
            return "value";
        }

       

    }
}
