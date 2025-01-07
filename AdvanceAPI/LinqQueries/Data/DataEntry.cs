using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueries.Data
{
    internal class DataEntry
    {

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp = new Employee
            {
                Id = 1,
                FirstName = "Rohanshu",
                LastName = "Banodha",
                Salary = 45000,
                IsManager = false,
                DepartmentId = 1
            };
            employees.Add(emp);

            emp = new Employee
            {
                Id = 2,
                FirstName = "Meet",
                LastName = "Joshi",
                Salary = 55000,
                IsManager = true,
                DepartmentId = 2
            };
            employees.Add(emp);

            emp = new Employee
            {
                Id = 3,
                FirstName = "Navneet",
                LastName = "Thakor",
                Salary = 55000,
                IsManager = true,
                DepartmentId = 1
            };
            employees.Add(emp);

            return employees;
        }


        public static List<Department> GetDepartment()
        {
            List<Department> departments = new List<Department>();
            Department dept = new Department
            {
                Id = 1,
                Name = "Developer"
            };
            departments.Add(dept);

            dept = new Department
            {
                Id = 2,
                Name = "DevOps"
            };
            departments.Add(dept);

            return departments;
        }
    }
}
