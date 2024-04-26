using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class Course
    {
        private readonly int CourseID;
        public string CourseTitle { get; }
        private Dictionary<Student, double> students;

        public Course(int id, string title)
        {
            CourseID = id;
            CourseTitle = title;
            students = new Dictionary<Student, double>();
        }

        public void AddStudent(Student student, double grade)
        {
            students.Add(student, grade);
            OnNumberOfStudentChange();
        }

        public void RemoveStudent(int studentID)
        {
            foreach (var student in students.Keys)
            {
                if (student.StudentID == studentID)
                {
                    students.Remove(student);
                    OnNumberOfStudentChange();
                    return;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Course ID: {0}\n", CourseID);
            sb.AppendFormat("Course Title: {0}\n", CourseTitle);
            sb.AppendLine("List of Students and Their Grades:");

            foreach (var student in students)
            {
                sb.AppendFormat("- {0} ({1}): {2}\n", student.Key.StudentName, student.Key.StudentID, student.Value);
            }

            return sb.ToString();
        }

        public event EventHandler NumberOfStudentChange;

        private void OnNumberOfStudentChange()
        {
            NumberOfStudentChange?.Invoke(this, EventArgs.Empty);
        }
    }
}