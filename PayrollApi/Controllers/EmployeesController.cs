using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollApi.Data;
using PayrollApi.Models;
using PayrollApi.View_Model;

namespace PayrollApi.Controllers
{


    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly FullStackDbContext _fullstackDbContext;

        public EmployeesController(FullStackDbContext fullstackDbContext)
        {
            _fullstackDbContext = fullstackDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _fullstackDbContext.Employeees.Select(x => new EmployeeViewModel {
                StaffID = x.StaffID,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                Salary = x.Salary,
                Department = x.Department,
                Password = x.Password,
                DOB = x.DOB,
                Status = ((Status)(x.Status)).ToString()
            }).ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employeeRequest)
        {

            await _fullstackDbContext.Employeees.AddAsync(employeeRequest);
            await _fullstackDbContext.SaveChangesAsync();

            return Ok(employeeRequest);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            var employee = await _fullstackDbContext.Employeees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, Employee updateEmployeeRequest)
        {
            var employee = await _fullstackDbContext.Employeees.FindAsync(id);


            if (employee == null)

            {
                return NotFound();
            }
            //Status status = (Status)updateEmployeeRequest.Status;
            employee.StaffID = updateEmployeeRequest.StaffID;
            employee.Name = updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Department = updateEmployeeRequest.Department;
            employee.DOB = updateEmployeeRequest.DOB;
            employee.Status = updateEmployeeRequest.Status;

            await _fullstackDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var employee = await _fullstackDbContext.Employeees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            _fullstackDbContext.Employeees.Remove(employee);
            await _fullstackDbContext.SaveChangesAsync();

            return Ok(employee);
        }

    }
}
