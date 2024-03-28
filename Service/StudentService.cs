using AutoMapper;
using Contracts;
using Entities;
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

        public IEnumerable<StudentDto> GetAllStudents(bool trackChanges)
        {
            var students = _repositoryManager.Student.GetAllStudents(trackChanges);
            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            return studentsDto;
        }

        public StudentDto GetStudent(Guid studentId, bool trackChanges)
        {
            var student = _repositoryManager.Student.GetStudent(studentId, trackChanges);
            if (student == null)
                throw new StudentNotFoundException(studentId);

            var studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;
        }
    }
}
