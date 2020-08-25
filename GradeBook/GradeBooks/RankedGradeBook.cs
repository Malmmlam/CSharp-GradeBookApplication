using System;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var averageGrades = Students.Select(stu => stu.AverageGrade).ToList();
            averageGrades.Sort();

            if (averageGrade >= 0.80 / averageGrades.Count)
                return 'A';
            else if (averageGrade > 0.60 / averageGrades.Count && averageGrade < 0.80 / averageGrades.Count)
                return 'B';
            else if (averageGrade > 0.40 / averageGrades.Count && averageGrade < 0.60 / averageGrades.Count)
                return 'C';
            else if (averageGrade > 0.20 / averageGrades.Count && averageGrade < 0.40 / averageGrades.Count)
                return 'D';
            else
                return 'F';
        }
    }
}