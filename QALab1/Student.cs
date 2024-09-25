namespace QALab1;

public class Student(string name)
{
    public string Name { get; } = name;
    private List<int> Grades { get; } = [];

    public void AddGrade(int grade)
    {
        Grades.Add(grade);
        Console.WriteLine($"Студент {Name} получил оценку {grade}.");
    }

    public List<int> GetGrades()
    {
        return Grades;
    }

    public double GetAverageGrade()
    {
        if (Grades.Count == 0) return 0;
        return Grades.Average();
    }
}