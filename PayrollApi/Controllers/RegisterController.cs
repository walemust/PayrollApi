using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollApi.Data;
using PayrollApi.Models;
using PayrollApi.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly FullStackDbContext _fullstackDbContext;

        public RegisterController(FullStackDbContext fullstackDbContext)
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

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginViewModel registerRequest)
        {

            //var staff =
            //     await _fullstackDbContext.Register2.Where(x => x.StaffID == registerRequest.StaffID && x.Password
            //     == registerRequest.Password).FirstOrDefaultAsync();

            //if (staff != null)
            //{
            //    rvm.StaffID = staff.StaffID;
            //    return Json("success");
            //}
            //else
            //{
            //    return Ok(null);
            //}

            ResponseViewModel rvm = new ResponseViewModel();


            try
            {
                var staffExistsAsync = await _fullstackDbContext.Employeees.Where(x => x.StaffID == registerRequest.StaffID).AnyAsync();
                if (staffExistsAsync)
                {
                    var staffDetails = await _fullstackDbContext.Employeees.Where(x => x.StaffID == registerRequest.StaffID && x.Password == HashedPassword(registerRequest.Password)).FirstOrDefaultAsync();

                    if (staffDetails != null)
                    {
                        rvm.Id = staffDetails.Id;
                        rvm.Message = "signed in successfully";
                        rvm.Code = "00";
                        return Json(rvm);
                    }
                    else
                    {
                        rvm.Message = "invalid credentials";
                        rvm.Code = "02";
                        return Json(rvm);
                    }

                }
                else
                {
                    rvm.Message = "this staff does not exist";
                    rvm.Code = "03";
                    return Json(rvm);
                }
            }
            catch (Exception)
            {
                rvm.Message = "An error occured";
                rvm.Code = "03";
                return Json(rvm);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Employee registerRequest)
        {
            try
            {
                var staffExistsAsync = await _fullstackDbContext.Employeees.Where(x => x.StaffID == registerRequest.StaffID).AnyAsync();
                if (staffExistsAsync == staffExistsAsync)
                {
                    return Json("User already exist");
                }
                var Employee = new Employee {
                    Name = registerRequest.Name,
                    Email = registerRequest.Email,
                    ChangePassword = registerRequest.ChangePassword,
                    Department = registerRequest.Department
                };
                _fullstackDbContext.Employeees.Add(Employee);
                await _fullstackDbContext.SaveChangesAsync();
                return Json("User added successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    }
