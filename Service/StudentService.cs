using Contracts;
using Entities;
using Service.Contracts;

namespace Service
{
    public class StudentService : IStudentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public StudentService(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public IEnumerable<Student> GetAllStudents(bool trackChanges) => 
            _repositoryManager.Student.GetAllStudents(trackChanges);
        
    }
}
