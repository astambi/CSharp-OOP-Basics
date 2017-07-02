using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var employees = GetEmployees();
        var resultMaxAvSalary = employees
            .GroupBy(e => e.Department)
            .Select(d => new
            {
                Department = d.Key,
                AvSalary = d.Average(emp => emp.Salary),
                Employees = d.OrderByDescending(emp => emp.Salary).ToList()
            })
            .OrderByDescending(d => d.AvSalary)
            .FirstOrDefault();

        if (resultMaxAvSalary != null)
        {
            Console.WriteLine($"Highest Average Salary: {resultMaxAvSalary.Department}");
            resultMaxAvSalary.Employees
                             .ForEach(e => Console.WriteLine(e.ToString()));
        }
    }

    private static List<Employee> GetEmployees()
    {
        var employees = new List<Employee>();
        var numberOfEmployees = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfEmployees; i++)
        {
            var employeeInfo = Console.ReadLine()
                               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // mandatory name, salary, position, department
            var employee = new Employee(
                            employeeInfo[0],
                            decimal.Parse(employeeInfo[1]),
                            employeeInfo[2],
                            employeeInfo[3]);
            // optional email, age
            if (employeeInfo.Length > 4)
            {
                var emailOrAge = employeeInfo[4];
                if (emailOrAge.Contains("@"))
                {
                    employee.Email = emailOrAge;
                }
                else
                {
                    employee.Age = int.Parse(emailOrAge);
                }
            }
            if (employeeInfo.Length > 5)
            {
                employee.Age = int.Parse(employeeInfo[5]);
            }
            employees.Add(employee);
        }
        return employees;
    }
}