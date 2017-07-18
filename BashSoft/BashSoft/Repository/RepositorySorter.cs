using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public class RepositorySorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsWithMarks, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                this.PrintStudents(studentsWithMarks
                             .OrderBy(x => x.Value)
                             .Take(studentsToTake)
                             .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                this.PrintStudents(studentsWithMarks
                             .OrderByDescending(x => x.Value)
                             .Take(studentsToTake)
                             .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (var keyValuePair in studentsSorted)
            {
                OutputWriter.PrintStudent(keyValuePair);
            }
        }
    }
}
