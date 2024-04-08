using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync(bool trackChanges);
        Task<StudentWithEnrollmentsDto> GetStudentAsync(Guid studentId, bool trackChanges);
        Task<StudentDto> CreateStudentAsync(StudentForCreationDto student);
        Task DeleteStudentAsync(Guid studentId, bool trackChanges);
        Task UpdateStudentAsync(Guid id, StudentForUpdateDto student, bool trackChanges);
        Task<(StudentForUpdateDto studentForUpdate, Student studentEntity)> GetStudentForPatchAsync(Guid studentId, bool trackChanges);
        Task SaveChangesForPatchAsync(StudentForUpdateDto studentForUpdate, Student studentEntity);


        IEnumerable<StudentDto> GetAllStudents(bool trackChanges);
        StudentWithEnrollmentsDto GetStudent(Guid studentId, bool trackChanges);

        StudentDto CreateStudent(StudentForCreationDto student);

        void DeleteStudent(Guid studentId, bool trackChanges);

        void UpdateStudent(Guid id, StudentForUpdateDto student, bool trackChanges);

        (StudentForUpdateDto studentForUpdate, Student studentEntity) GetStudentForPatch(Guid studentId, bool trackChanges);
        void SaveChangesForPatch(StudentForUpdateDto studentForUpdate, Student studentEntity);
    }
}
