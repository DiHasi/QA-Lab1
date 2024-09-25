using QALab1;

var course = new Course("Программирование", new DateTime(2024, 9, 1), new DateTime(2024, 12, 1));
var student = new Student("Иван");
var student1 = new Student("Мария");
var student2 = new Student("Анна");

Console.WriteLine(course.AddStudent(student));
Console.WriteLine(course.AddStudent(student1));
Console.WriteLine(course.AddStudent(student2));

Console.WriteLine(new string('-', 50));

Console.WriteLine(course.AddGradeToStudent("Иван", 5));
Console.WriteLine(course.AddGradeToStudent("Иван", 4));
Console.WriteLine(course.AddGradeToStudent("Иван", 3));

Console.WriteLine(new string('-', 50));

Console.WriteLine(course.AddGradeToStudent("Мария", 4));
Console.WriteLine(course.AddGradeToStudent("Мария", 5));
Console.WriteLine(course.AddGradeToStudent("Мария", 5));

Console.WriteLine(new string('-', 50));

Console.WriteLine(course.ShowStudents());

Console.WriteLine(new string('-', 50));

Console.WriteLine(course.ShowAverageGrades());

Console.WriteLine(new string('-', 50));

Console.WriteLine(course.RemoveStudent("Иван"));

Console.WriteLine(new string('-', 50));

Console.WriteLine(course.ShowStudents());