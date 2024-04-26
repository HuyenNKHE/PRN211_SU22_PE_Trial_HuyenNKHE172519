using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class Student
    {
        public int StudentID { get; }
        public string StudentName { get; }

        public Student(int id, string name)
        {
            StudentID = id;
            StudentName = name;
        }
    }
}