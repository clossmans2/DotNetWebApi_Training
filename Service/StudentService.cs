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

        public StudentDto CreateStudent(StudentForCreationDto student)
        {
            var studentEntity = _mapper.Map<Student>(student);
            studentEntity.EnrollmentDate = System.DateTime.Now;
            _repositoryManager.Student.CreateStudent(studentEntity);
            _repositoryManager.Save();
            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);
            return studentToReturn;
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

        public void DeleteStudent(Guid studentId, bool trackChanges)
        {
            var student = _repositoryManager.Student.GetStudent(studentId, trackChanges);
            if (student == null)
                throw new StudentNotFoundException(studentId);

            _repositoryManager.Student.DeleteStudent(student);
            _repositoryManager.Save();
        }

        public async Task DeleteStudentAsync(Guid studentId, bool trackChanges)
        {
            var student = await _repositoryManager.Student.GetStudentAsync(studentId, trackChanges);
            if (student == null)
                throw new StudentNotFoundException(studentId);

            _repositoryManager.Student.DeleteStudent(student);
            await _repositoryManager.SaveAsync();
        }

        public IEnumerable<StudentDto> GetAllStudents(bool trackChanges)
        {
            var students = _repositoryManager.Student.GetAllStudents(trackChanges);
            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            return studentsDto;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync(bool trackChanges)
        {
            var students = await _repositoryManager.Student.GetAllStudentsAsync(trackChanges);
            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            return studentsDto;
        }

        public StudentWithEnrollmentsDto GetStudent(Guid studentId, bool trackChanges)
        {
            var student = _repositoryManager.Student.GetStudent(studentId, trackChanges);
            if (student == null)
                throw new StudentNotFoundException(studentId);

            var enrollments = _repositoryManager.Enrollment.GetAllEnrollments(studentId, trackChanges);
            student.Enrollments = (ICollection<Enrollment>?)enrollments;
            var studentWithEnrollmentsDto = _mapper.Map<StudentWithEnrollmentsDto>(student);

            return studentWithEnrollmentsDto;
        }

        public async Task<StudentWithEnrollmentsDto> GetStudentAsync(Guid studentId, bool trackChanges)
        {
            var student = await _repositoryManager.Student.GetStudentAsync(studentId, trackChanges);
            if (student == null)
                throw new StudentNotFoundException(studentId);

            var enrollments = await _repositoryManager.Enrollment.GetEnrollmentsForStudentAsync(studentId, trackChanges);
            student.Enrollments = (ICollection<Enrollment>?)enrollments;
            var studentWithEnrollmentsDto = _mapper.Map<StudentWithEnrollmentsDto>(student);
            return studentWithEnrollmentsDto;
        }

        public (StudentForUpdateDto studentForUpdate, Student studentEntity) GetStudentForPatch(Guid studentId, bool trackChanges)
        {
            var studentEntity = _repositoryManager.Student.GetStudent(studentId, trackChanges);
            if (studentEntity == null)
                throw new StudentNotFoundException(studentId);

            var studentForUpdate = _mapper.Map<StudentForUpdateDto>(studentEntity);
            return (studentForUpdate, studentEntity);
        }

        public async Task<(StudentForUpdateDto studentForUpdate, Student studentEntity)> 
            GetStudentForPatchAsync(Guid studentId, bool trackChanges)
        {
            var studentEntity = await _repositoryManager.Student.GetStudentAsync(studentId, trackChanges);
            if (studentEntity == null)
                throw new StudentNotFoundException(studentId);

            var studentForUpdate = _mapper.Map<StudentForUpdateDto>(studentEntity);
            return (studentForUpdate, studentEntity);
        }

        public void SaveChangesForPatch(StudentForUpdateDto studentForUpdate, Student studentEntity)
        {
            _mapper.Map(studentForUpdate, studentEntity);
            _repositoryManager.Save();
        }

        public async Task SaveChangesForPatchAsync(StudentForUpdateDto studentForUpdate, Student studentEntity)
        {
            _mapper.Map(studentForUpdate, studentEntity);
            await _repositoryManager.SaveAsync();
        }

        public void UpdateStudent(Guid id, StudentForUpdateDto studentForUpdate, bool trackChanges)
        {
            var studentEntity = _repositoryManager.Student.GetStudent(id, trackChanges);
            if (studentEntity == null)
                throw new StudentNotFoundException(id);

            _mapper.Map(studentForUpdate, studentEntity);
            _repositoryManager.Save();
        }

        public async Task UpdateStudentAsync(Guid id, StudentForUpdateDto studentForUpdate, bool trackChanges)
        {
            var studentEntity = await _repositoryManager.Student.GetStudentAsync(id, trackChanges);
            if (studentEntity == null)
                throw new StudentNotFoundException(id);

            _mapper.Map(studentForUpdate, studentEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
