using System;
using System.Linq;
using System.Text;

namespace E03_Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10 ||
                    !value.All(char.IsLetterOrDigit)) // NB!
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder
                .Append(base.ToString())
                .AppendLine($"Faculty number: {this.FacultyNumber}");
            return builder.ToString();
        }
    }
}
