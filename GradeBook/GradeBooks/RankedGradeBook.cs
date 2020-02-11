using GradeBook.Enums;
using System;
using System.Linq;

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
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var control = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select( e => e.AverageGrade).ToList();

            if (grades[control-1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[(control*2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[(control*3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[(control*4) - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
