using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApi.Models
{
    public class StatusClassEnum
    {
    }
    public enum Status
    {
        Leave = 1,
        Resigned,
        Terminated,
        Active,
        Probation,
        Dead,
    }
}
