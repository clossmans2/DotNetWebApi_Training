using Entities;

namespace Service.Contracts
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents(bool trackChanges);
    }
}
