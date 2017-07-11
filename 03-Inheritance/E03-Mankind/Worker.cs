using System;
using System.Text;

namespace E03_Mankind
{
    public class Worker : Human
    {
        private const int workDaysPerWeek = 5;

        private decimal weeklySalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weeklySalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeeklySalary = weeklySalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeeklySalary
        {
            get { return this.weeklySalary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weeklySalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursPerDay = value;
            }
        }

        private decimal CalculateSalaryPerHour()
        {
            return this.WeeklySalary / workDaysPerWeek / this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder
                .Append(base.ToString())
                .AppendLine($"Week Salary: {this.WeeklySalary:f2}")
                .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
                .AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");
            return builder.ToString();
        }
    }
}
