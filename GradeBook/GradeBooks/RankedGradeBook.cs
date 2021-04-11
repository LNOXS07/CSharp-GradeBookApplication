using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {

        }

        public RankedGradeBook()
        {
            Type = GradeBookType.Ranked;
        }
    }
}
