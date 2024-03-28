using Entities;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IStudentService
    {
        IEnumerable<StudentDto> GetAllStudents(bool trackChanges);
        StudentDto GetStudent(Guid studentId, bool trackChanges);

        StudentDto CreateStudent(StudentForCreationDto student);
    }
}
