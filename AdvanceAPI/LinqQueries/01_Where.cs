using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqQueries.Data;

namespace LinqQueries
{
    internal class WhereDemo
    {
        internal static void WhereDemoMethod()
        {
            List<Employee> empList = DataEntry.GetEmployees();
            List<Department> deptList = DataEntry.GetDepartment();

            // Where Query
            var filteredList = empList.Where(E => E.IsManager == false);

            //foreach (var emp in filteredList)
            //{
            //    Console.WriteLine($"{emp.Id}, {emp.FirstName}, {emp.IsManager}");
            //}


            // Query Syntax for join query
            var customResult = from emp in empList
                         join dept in deptList
                         on emp.DepartmentId equals dept.Id
                         select new
                         {
                             Id = emp.Id,
                             Name = emp.FirstName + emp.LastName,
                             Dept_Name = dept.Name
                         };
            //foreach (var emp in result)
            //{
            //    Console.WriteLine($"{emp.Id}, {emp.Name}, {emp.Dept_Name}");
            //}



            // Average and Max
            double avgSalary = empList.Average(emp => emp.Salary);
            int maxSalary = empList.Max(emp => emp.Salary);

            //Console.WriteLine($"Average Salary: {avgSalary}, Max Salary: {maxSalary}");



            // Select Query
            var selectResult = empList.Select(e => new
            {
                FullName = e.FirstName + " " + e.LastName,
                AnnualSalary = e.Salary*12
            });

            //foreach (var e in selectResult)
            //{
            //    Console.WriteLine($"{e.FullName, -20} {e.AnnualSalary, 10}");
            //}



            // Chaining Query - Select and where - Method Syntax
            var chainedResult = empList.Select(e => new
            {
                FullName = e.FirstName + " " + e.LastName,
                AnnualSalary = e.Salary * 12
            }).Where(e => e.AnnualSalary < 650000);

            //foreach (var e in chainedResult)
            //{
            //    Console.WriteLine($"{e.FullName,-20} {e.AnnualSalary,10}");
            //}



            // Query Syntax - Select Query
            dynamic res = from e in empList
                          select new
                          {
                              FullName = e.FirstName + "-" + e.LastName,
                              AnnualSalary = e.Salary * 12
                          };
            //foreach (var e in res)
            //{
            //    Console.WriteLine($"{e.FullName,-20} {e.AnnualSalary,10}");
            //}

            // Query Syntax - Chaining - Select + Where
            res = from e in empList
                  where e.IsManager == false
                  select new
                  {
                      FullName = e.FirstName + "--" + e.LastName,
                      AnnualSalary = e.Salary * 12
                  };

            // these are deffered executions i.e gets executed in foreach loop when they are actually getting used somewhere.
            // proof: below added employee after the query written above.
            empList.Add(new Employee
            {
                Id = 4,
                FirstName = "Jay",
                LastName = "Kalbi",
                Salary = 33000,
                IsManager = false
            });


            // for immediate execution, only add some method like .ToList() to the query syntax
            // so that it will force the query to get executed in order to execute ToList().
            // Thus in this way we can make queries execute immediately and not lazily.
            //res = (from e in empList
            //      where e.IsManager == false
            //      select new
            //      {
            //          FullName = e.FirstName + "--" + e.LastName,
            //          AnnualSalary = e.Salary * 12
            //      }).ToList();

            //foreach (var e in res)
            //{
            //    Console.WriteLine($"{e.FullName,-20} {e.AnnualSalary,10}");
            //}


            // method syntax for Join Query
            res = deptList.Join(empList,
                dept => dept.Id,
                emp => emp.DepartmentId,
                (dept,emp) => new
                {
                    FullName = emp.FirstName+"~"+emp.LastName,
                    DeptName = dept.Name
                });
            //foreach (var e in res)
            //{
            //    Console.WriteLine($"{e.FullName,-20} {e.DeptName,10}");
            //}


            // Left Outer Join Method Syntax
            res = deptList.GroupJoin(empList,
                dept => dept.Id,
                emp => emp.DepartmentId,
                (dept, empGroup)=> new
                {
                    Employees = empGroup,
                    DepartmentName = dept.Name
                });

            res = from dept in deptList
                  join emp in empList
                  on dept.Id equals emp.DepartmentId
                  into empGroup
                  select new
                  {
                      Employees = empGroup,
                      DepartmentName = dept.Name
                  };
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"\nDepartment Name: {item.DepartmentName}");
            //    foreach (var e in item.Employees)
            //    {
            //        Console.WriteLine($"{e.FirstName} {e.LastName}");
            //    }
            //}


            // order by, then by using method syntax
            res = empList.Join(deptList,
                e => e.DepartmentId,
                d => d.Id,
                (emp, dept) => new
                {
                    EmpId = emp.Id,
                    Name = emp.FirstName,
                    Dept = dept.Name,
                    DeptId = emp.DepartmentId
                }).OrderBy(o => o.DeptId).ThenByDescending(o => o.Name);

            // query syntax form
            res = from emp in empList
                  join dept in deptList
                  on emp.DepartmentId equals dept.Id
                  orderby emp.DepartmentId, emp.FirstName descending
                  select new
                  {
                      EmpId = emp.Id,
                      Name = emp.FirstName,
                      Dept = dept.Name,
                      DeptId = emp.DepartmentId
                  };

            //foreach (var e in res)
            //{
            //    Console.WriteLine($"Emp Id: {e.EmpId} Name: {e.Name} Dept: {e.Dept} DeptId: {e.DeptId}");
            //}


            // group by  --> it is deferred execution -> returns igrouping generic interface (tolookup also)

            // query syntax
            res = from emp in empList
                  group emp by emp.DepartmentId;

            // method syntax
            res = empList.GroupBy(e => e.DepartmentId);


            // to lookup  --> immediate execution (same funcionality as groupby)
            res = empList.ToLookup(e => e.DepartmentId);
            
            foreach (var empGroup in res)
            {
                Console.WriteLine($"DepartmentId: {empGroup.Key}");
                foreach (Employee e in empGroup)
                {
                    Console.WriteLine($"\tId: {e.Id} Name: {e.FirstName}");
                }
            }



        }
    }
}
