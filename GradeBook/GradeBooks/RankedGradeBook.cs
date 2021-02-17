using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int count = this.Students.Count;
            if (count < 5)
            {
                throw new InvalidOperationException();
            }

            int x = count / 5; // num students to drop letter grade

            // put average grades in order
            List<double> avgGrades = new List<double>();

            // calculate and store average grades in avgGrades
            foreach(var student in this.Students)
            {
                // double avg = 0.0;
                // double gradeCount = student.Grades.Count;
                // foreach(var grade in student.Grades)
                // {
                //     avg += grade;
                // }
                // avg /= gradeCount;
                double avg = student.Grades.Average();
                avgGrades.Add(avg);
            }

            // sort average grades
            avgGrades = avgGrades.OrderByDescending(i => i).ToList();

            // {g0, g1, g2, g3, g4, g5, g6}
            for(int i = 0; i < count; i++)
            {
                if (averageGrade > avgGrades.ElementAt<double>(i))
                {
                    if (i <= x)
                        return 'A';
                    else if (i <= x*2)
                        return 'B';
                    else if (i <= x*3)
                        return 'C';
                    else if (i <= x*4)
                        return 'D';
                    else
                        break;
                }
            }

            return 'F';
        }
    }
}