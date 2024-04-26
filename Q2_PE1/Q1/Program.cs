using Q1;

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student(1, "Trung");
        Student student2 = new Student(2, "Hoa");
        Student student3 = new Student(3, "Vinh");
        Student student4 = new Student(4, "Hoang Anh");

        Course course = new Course(1, "Prn_sum21");
        course.AddStudent(student1, 7.5);
        course.AddStudent(student2, 7.8);
        course.AddStudent(student3, 7.4);

        Console.WriteLine(course.ToString());


        course.NumberOfStudentChange += (oldNumber, newNumber) =>
        {
            Console.WriteLine($"Number of students changed from {oldNumber} to {newNumber}");
        };

        course.RemoveStudent(2);

        Console.WriteLine("\n-------------- After Remove:");
        Console.WriteLine(course.ToString());

        Console.WriteLine("\n-------------- After add event handler:");
        course.AddStudent(student4, 8);
        course.RemoveStudent(1);
        Console.WriteLine(course.ToString());

        Console.ReadLine();
    }

}