using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueries.Data
{
    internal class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Salary { get; set; }

        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }
    }
}
