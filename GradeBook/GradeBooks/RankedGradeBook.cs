using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (Students.Count < 5) throw new InvalidOperationException("You need 5 or more students for Ranked Grading");

            //stopped at trying to figure out a way to rank students based on group average and knocking grades based on group average and count

            ///<summary>
            ///<list type="number">
            ///TODO:<item> Create a Threshold Variable
            ///      <list type="bullet">
            ///TODO:      <item>Calculate the 20% threshold based on count of List<Student> Students { get; set; } of Student.cs</item>
            ///TODO:      <item>Round up the Students.Count to nearest whole number (math.ceiling)</item>
            ///TODO:      <item>Cast to an int because later we'll use it for an index that only accepts int types</item>
            ///      </list>
            ///</item>
            ///TODO:<item>Arrange students' average grades by descending order. It will help identify where the input grade falls in relation to other grades
            ///      <list type="bullet">
            ///TODO:      <item>Create a new var (grades) and use LINQ to OrderByDescending the List<Student> Students { get; set; } of Student.cs</item>
            ///TODO:      <item>Add e => e.AverageGrade to the ordering to order by Average Grade Property of Student.cs</item>
            ///TODO:      <item>Add .Select(e => e.AverageGrade) to select only the average grade of a student and not the entire Student object</item>
            ///TODO:      <item>Turn into a list by using .ToList</item>
            ///      </list>
            ///</item>
            ///<item>Start a series of if/else if to enumerate through the list of students grades using the var grades to determine the grade (A-F)
            ///
            ///      <list type="bullet">
            ///TODO:      <item>if(grades[threshold - 1] <= averageGrade) then A (note how the threshold is - 1 for 0-based index of the var threshold compared to the averageGrade property of Student.cs</item>
            ///TODO:      <item>if(grades[(threshold * 2) - 1] <= averageGrade) then B (note how we double the number of threshold to be able to drop 2 grades. * 3 to drop 3, then * 4, and then default to F by process of elimination</item>
            ///      </list>
            ///</item>
            ///</list>
            ///</summary>

            var threshold = (int) Math.Ceiling(Students.Count * 0.2);

            var gradesOrdering = Students.OrderByDescending(o => o.AverageGrade)
                                                            .Select(o => o.AverageGrade)
                                                            .ToList();

            if (gradesOrdering[threshold - 1] <= averageGrade)
                return 'A';
            else if (gradesOrdering[(threshold *2) - 1] <= averageGrade)
                return 'B';
            else if (gradesOrdering[(threshold * 3) - 1] <= averageGrade)
                return 'C';
            else if (gradesOrdering[(threshold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}
