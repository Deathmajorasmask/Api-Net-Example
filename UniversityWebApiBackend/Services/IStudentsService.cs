using UniversityWebApiBackend.Models.DataModels;

namespace UniversityWebApiBackend.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetStudentsWithCourses();
        IEnumerable<Student> GetStudentsWithNotCourses();
    }
}
