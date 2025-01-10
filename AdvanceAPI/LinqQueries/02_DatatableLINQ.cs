using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LinqQueries
{
    class LinqQuery
    {
        public static void LinqQueriesDemo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Department", typeof(string));
            dt.Columns.Add("Salary", typeof(decimal));

            dt.Rows.Add(1, "Alice", "HR", 50000);
            dt.Rows.Add(2, "Bob", "IT", 60000);
            dt.Rows.Add(3, "Charlie", "HR", 55000);
            dt.Rows.Add(4, "Dave", "IT", 75000);

            // LINQ Queries on DataTable

            // 1. WHERE: Filter employees with Salary > 60000
            var highSalaryEmployees = dt.AsEnumerable()
                .Where(row => row.Field<decimal>("Salary") > 60000)
                .Select(row => new { Name = row.Field<string>("Name"), Salary = row.Field<decimal>("Salary") });
            Console.WriteLine("Employees with Salary > 60000:");
            foreach (var emp in highSalaryEmployees)
                Console.WriteLine($"Name: {emp.Name}, Salary: {emp.Salary}");

            // 2. SELECT: Project only Name and Department columns
            var selectedColumns = dt.AsEnumerable()
                .Select(row => new { Name = row.Field<string>("Name"), Department = row.Field<string>("Department") });
            Console.WriteLine("\nName and Department:");
            foreach (var emp in selectedColumns)
                Console.WriteLine($"Name: {emp.Name}, Department: {emp.Department}");

            // 3. ORDERBY: Order employees by Salary
            var orderedBySalary = dt.AsEnumerable()
                .OrderBy(row => row.Field<decimal>("Salary"));
            Console.WriteLine("\nEmployees Ordered by Salary:");
            foreach (var emp in orderedBySalary)
                Console.WriteLine($"Name: {emp.Field<string>("Name")}, Salary: {emp.Field<decimal>("Salary")}");

            // 4. THENBY: Order by Department, then by Name
            var orderedByDeptAndName = dt.AsEnumerable()
                .OrderBy(row => row.Field<string>("Department"))
                .ThenBy(row => row.Field<string>("Name"));
            Console.WriteLine("\nEmployees Ordered by Department and then Name:");
            foreach (var emp in orderedByDeptAndName)
                Console.WriteLine($"Department: {emp.Field<string>("Department")}, Name: {emp.Field<string>("Name")}");

            // 5. GROUPBY: Group employees by Department
            var groupedByDepartment = dt.AsEnumerable()
                .GroupBy(row => row.Field<string>("Department"));
            Console.WriteLine("\nEmployees Grouped by Department:");
            foreach (var group in groupedByDepartment)
            {
                Console.WriteLine($"Department: {group.Key}");
                foreach (var emp in group)
                    Console.WriteLine($"  Name: {emp.Field<string>("Name")}, Salary: {emp.Field<decimal>("Salary")}");
            }

            // 6. AGGREGATE: Calculate Total and Average Salary
            var totalSalary = dt.AsEnumerable().Sum(row => row.Field<decimal>("Salary"));
            var averageSalary = dt.AsEnumerable().Average(row => row.Field<decimal>("Salary"));
            Console.WriteLine($"\nTotal Salary: {totalSalary}");
            Console.WriteLine($"Average Salary: {averageSalary}");

            // 7. COUNT: Count employees in each Department
            var countByDepartment = dt.AsEnumerable()
                .GroupBy(row => row.Field<string>("Department"))
                .Select(group => new { Department = group.Key, Count = group.Count() });
            Console.WriteLine("\nEmployee Count by Department:");
            foreach (var dept in countByDepartment)
                Console.WriteLine($"Department: {dept.Department}, Count: {dept.Count}");
        }
    }

}
