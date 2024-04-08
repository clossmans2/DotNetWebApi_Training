using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class StudentService : IStudentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public StudentService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        #region Sync Methods
        public IEnumerable<StudentDto> GetAllStudents(bool trackChanges)
        {
            var students = _repositoryManager.Student.GetAllStudents(trackChanges);
            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            return studentsDto;
        }
        public StudentWithEnrollmentsDto GetStudent(Guid studentId, bool trackChanges)
        {
            var student = GetStudentAndCheckIfItExists(studentId, trackChanges);

            var enrollments = _repositoryManager.Enrollment.GetAllEnrollments(studentId, trackChanges);
            student.Enrollments = (ICollection<Enrollment>?)enrollments;
            var studentWithEnrollmentsDto = _mapper.Map<StudentWithEnrollmentsDto>(student);

            return studentWithEnrollmentsDto;
        }
        public StudentDto CreateStudent(StudentForCreationDto student)
        {
            var studentEntity = _mapper.Map<Student>(student);
            studentEntity.EnrollmentDate = System.DateTime.Now;
            _repositoryManager.Student.CreateStudent(studentEntity);
            _repositoryManager.Save();
            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);
            return studentToReturn;
        }
        public void UpdateStudent(Guid id, StudentForUpdateDto studentForUpdate, bool trackChanges)
        {
            var studentEntity = GetStudentAndCheckIfItExists(id, trackChanges);

            _mapper.Map(studentForUpdate, studentEntity);
            _repositoryManager.Save();
        }
        public (StudentForUpdateDto studentForUpdate, Student studentEntity) GetStudentForPatch(Guid studentId, bool trackChanges)
        {
            var studentEntity = GetStudentAndCheckIfItExists(studentId, trackChanges);

            var studentForUpdate = _mapper.Map<StudentForUpdateDto>(studentEntity);
            return (studentForUpdate, studentEntity);
        }
        public void SaveChangesForPatch(StudentForUpdateDto studentForUpdate, Student studentEntity)
        {
            _mapper.Map(studentForUpdate, studentEntity);
            _repositoryManager.Save();
        }
        public void DeleteStudent(Guid studentId, bool trackChanges)
        {
            var student = GetStudentAndCheckIfItExists(studentId, trackChanges);

            _repositoryManager.Student.DeleteStudent(student);
            _repositoryManager.Save();
        }

        #endregion Sync Methods

        #region Async Methods

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync(bool trackChanges)
        {
            var students = await _repositoryManager.Student.GetAllStudentsAsync(trackChanges);
            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            return studentsDto;
        }
        public async Task<StudentWithEnrollmentsDto> GetStudentAsync(Guid studentId, bool trackChanges)
        {
            var student = await GetStudentAndCheckIfItExistsAsync(studentId, trackChanges);

            var enrollments = await _repositoryManager.Enrollment.GetEnrollmentsForStudentAsync(studentId, trackChanges);
            student.Enrollments = (ICollection<Enrollment>?)enrollments;
            var studentWithEnrollmentsDto = _mapper.Map<StudentWithEnrollmentsDto>(student);
            return studentWithEnrollmentsDto;
        }
        public async Task<StudentDto> CreateStudentAsync(StudentForCreationDto student)
        {
            var studentEntity = _mapper.Map<Student>(student);
            studentEntity.EnrollmentDate = System.DateTime.Now;
            _repositoryManager.Student.CreateStudent(studentEntity);
            await _repositoryManager.SaveAsync();
            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);
            return studentToReturn;
        }

        public async Task<(StudentForUpdateDto studentForUpdate, Student studentEntity)> 
            GetStudentForPatchAsync(Guid studentId, bool trackChanges)
        {
            var studentEntity = await GetStudentAndCheckIfItExistsAsync(studentId, trackChanges);

            var studentForUpdate = _mapper.Map<StudentForUpdateDto>(studentEntity);
            return (studentForUpdate, studentEntity);
        }
        public async Task SaveChangesForPatchAsync(StudentForUpdateDto studentForUpdate, Student studentEntity)
        {
            _mapper.Map(studentForUpdate, studentEntity);
            await _repositoryManager.SaveAsync();
        }
        public async Task UpdateStudentAsync(Guid id, StudentForUpdateDto studentForUpdate, bool trackChanges)
        {
            var studentEntity = await GetStudentAndCheckIfItExistsAsync(id, trackChanges);

            _mapper.Map(studentForUpdate, studentEntity);
            await _repositoryManager.SaveAsync();
        }
        public async Task DeleteStudentAsync(Guid studentId, bool trackChanges)
        {
            var student = await GetStudentAndCheckIfItExistsAsync(studentId, trackChanges);

            _repositoryManager.Student.DeleteStudent(student);
            await _repositoryManager.SaveAsync();
        }

        #endregion Async Methods

        #region Helper Methods

        private async Task<Student> GetStudentAndCheckIfItExistsAsync(Guid studentId, bool trackChanges)
        {
            var student = await _repositoryManager.Student.GetStudentAsync(studentId, trackChanges);
            if (student == null)
                throw new StudentNotFoundException(studentId);

            return student;
        }

        private Student GetStudentAndCheckIfItExists(Guid studentId, bool trackChanges)
        {
            var student = _repositoryManager.Student.GetStudent(studentId, trackChanges);
            if (student == null)
                throw new StudentNotFoundException(studentId);

            return student;
        }

        #endregion Helper Methods
    }
}
