using BashSoft.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft.Models
{
    public class Student
    {
        private string userName;
        private Dictionary<string, Course> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public Student(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, Course>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string UserName
        {
            get { return this.userName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.userName = value;
            }
        }

        public IReadOnlyDictionary<string, Course> EnrolledCourses
        {
            get { return this.enrolledCourses; }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return this.marksByCourseName; }
        }

        public void EnrollInCourse(Course course)
        {
            if (this.EnrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
            }
            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!this.EnrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }
            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new InvalidNumberOfScoresException();
            }
            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            double percntageOfSolvedExam = scores.Sum() / (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            double mark = percntageOfSolvedExam * 4 + 2;

            return mark;
        }
    }
}