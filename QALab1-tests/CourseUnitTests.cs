using QALab1;

namespace QALab1_tests;

// Реализация интерфейса IDisposable (метод Dispose()) - аналог [TestCleanup] из MSTest
public class CourseUnitTests : IDisposable
{
    private readonly Student _student;

    // Создание объекта в конструкторе - аналог [TestInitialize] из MSTest
    public CourseUnitTests()
    {
        _student = new Student("Иван");
    }
    
    // [Fact] - аналог [TestMethod] из MSTest
    [Fact]
    public void Can_add_a_student_with_valid_data()
    {
        // Arrange
        var course = new Course("Программирование", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
        
        // Act
        var result = course.AddStudent(_student);
        
        // Assert
        Assert.True(course.IsStudentEnrolled(_student.Name));
        Assert.Equal($"Студент {_student.Name} добавлен на курс {course.Name}", result);
    }
    
    [Fact]
    public void Can_detect_student_duplication()
    {
        // Arrange
        var course = new Course("Программирование", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
        course.AddStudent(_student);
        Assert.True(course.IsStudentEnrolled(_student.Name));
        
        // Act
        var result = course.AddStudent(_student);
        
        // Assert
        Assert.Equal($"Студент {_student.Name} уже зачислен на курс", result);
    }
    
    public static List<object[]> DataForTestsWithoutExitingStudent()
    {
        return
        [
            [DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), "Курс Программирование ещё не начался"],

            [DateTime.Now.AddDays(1), DateTime.Now.AddDays(-1), "Курс Программирование ещё не начался"],
            
            [DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1), "Курс Программирование уже завершён"]
        ];

    }
    
    
    // [Theory] - аналог [DataTestMember] из MSTest
    // [MemberData()] или [InlineData()] - аналог [DataRow] из MSTest
    [Theory]
    [MemberData(nameof(DataForTestsWithoutExitingStudent))] 
    public void Can_detect_an_invalid_date_without_exiting_student(DateTime startDate, DateTime endDate, string expected)
    {
        // Arrange
        var course = new Course("Программирование", startDate, endDate);
        
        // Act
        var result = course.AddStudent(_student);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    public static List<object[]> DataForTestsWithExitingStudent()
    {
        return
        [
            [DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), "Курс Программирование ещё не начался"],

            [DateTime.Now.AddDays(1), DateTime.Now.AddDays(-1), "Курс Программирование ещё не начался"],
            
            [DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1), "Курс Программирование уже завершён"]
        ];

    }
    
    [Theory]
    [MemberData(nameof(DataForTestsWithExitingStudent))] 
    public void Can_detect_an_invalid_date_with_exiting_student(DateTime startDate, DateTime endDate, string expected)
    {
        // Arrange
        var course = new Course("Программирование", startDate, endDate);
        course.AddStudent(_student);
        
        // Act
        var result = course.AddStudent(_student);
        
        // Assert
        Assert.Equal(expected, result);
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}