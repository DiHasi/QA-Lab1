namespace QALab1;

public class Course(string name, DateTime startDate, DateTime endDate)
{
    public string Name { get; } = name;
    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; } = endDate;
    private List<Student> Students { get; } = [];

    public string AddStudent(Student student)
    {
        if (DateTime.Now < StartDate) return $"Курс {Name} ещё не начался";

        if (DateTime.Now > EndDate) return $"Курс {Name} уже завершён";

        if (Students.Any(s => s.Name == student.Name)) return $"Студент {student.Name} уже зачислен на курс";

        Students.Add(student);
        return $"Студент {student.Name} добавлен на курс {Name}";
    }

    public string RemoveStudent(string name)
    {
        if (DateTime.Now < StartDate) return $"Курс {Name} ещё не начался, удаление студентов невозможно";

        if (DateTime.Now > EndDate) return $"Курс {Name} уже завершён, удаление студентов невозможно";

        var student = Students.FirstOrDefault(s => s.Name == name);
        if (student != null)
        {
            Students.Remove(student);
            return $"Студент {name} удалён с курса {Name}";
        }

        return $"Студент с именем {name} не найден";
    }

    public string AddGradeToStudent(string studentName, int grade)
    {
        if (DateTime.Now < StartDate) return $"Курс {Name} ещё не начался";

        if (DateTime.Now > EndDate) return $"Курс {Name} уже завершён";

        var student = Students.FirstOrDefault(s => s.Name == studentName);
        if (student != null)
        {
            student.AddGrade(grade);
            return $"Оценка {grade} добавлена студенту {studentName}";
        }

        return $"Студент с именем {studentName} не найден";
    }

    public string ShowStudents()
    {
        if (Students.Count == 0)
        {
            return "Нет зарегистрированных студентов";
        }

        var studentList = $"Список студентов на курсе {Name}:\n";
        foreach (var student in Students) studentList += $"{student.Name}\n";
        return studentList.Trim();
    }

    public string ShowCourseDates()
    {
        return
            $"Курс {Name} начинается {StartDate.ToShortDateString()} и заканчивается {EndDate.ToShortDateString()}";
    }

    public bool IsStudentEnrolled(string studentName)
    {
        return Students.Any(s => s.Name == studentName);
    }

    public string ShowAverageGrades()
    {
        var averageGradesList = new List<string>();
        foreach (var student in Students)
        {
            var average = student.GetAverageGrade();
            averageGradesList.Add($"Средний балл студента {student.Name}: {average:F2}");
        }

        return string.Join("\n", averageGradesList);
    }
}