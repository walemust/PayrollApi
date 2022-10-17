using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayrollApi.Entities;

namespace PayrollApi.Models
{
    public class Register : BaseEntity
    {
        //public int Id { get; set; }
        public string StaffID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ChangePassword { get; set; }
        public long Phone { get; set; }
        public long Salary { get; set; }
        public string Department { get; set; }
        public string DOB { get; set; }
    }
}
