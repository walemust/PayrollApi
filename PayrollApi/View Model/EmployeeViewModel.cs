using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApi.View_Model
{
    public class EmployeeViewModel
    {
        public string StaffID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public long Salary { get; set; }
        public string Department { get; set; }
        public string Password { get; set; }
        public string DOB { get; set; }
        public string Status { get; set; }
        public string ChangePassword { get; set; }
    }
}
