using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        public static string HashedPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedpassword = hash.ComputeHash(passwordBytes);
            var hexString = BitConverter.ToString(hashedpassword);
            return hexString;
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
            var addStaff = new Employee 
            {
                StaffID = employeeRequest.StaffID,
                Name = employeeRequest.Name,
                Email = employeeRequest.Email,
                Phone = employeeRequest.Phone,
                Salary = employeeRequest.Salary,
                Department = employeeRequest.Department,
                Password = HashedPassword(employeeRequest.Password),
                DOB = employeeRequest.DOB,
                Status = employeeRequest.Status,
                ChangePassword = employeeRequest.ChangePassword,
            };

            await _fullstackDbContext.Employeees.AddAsync(addStaff);
            await _fullstackDbContext.SaveChangesAsync();
            return Ok("Staff added successfully");
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
            employee.Password = HashedPassword(updateEmployeeRequest.Password);

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
