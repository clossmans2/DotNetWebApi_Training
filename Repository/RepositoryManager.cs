using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IStudentRepository> _studentRepository;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<IInstructorRepository> _instructorRepository;
        private readonly Lazy<IEnrollmentRepository> _enrollmentRepository;
        private readonly Lazy<ICourseAssignmentRepository> _courseAssignmentRepository;
        private readonly Lazy<IOfficeAssignmentRepository> _officeAssignmentRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(_repositoryContext));
            _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(_repositoryContext));
            _instructorRepository = new Lazy<IInstructorRepository>(() => new InstructorRepository(_repositoryContext));
            _enrollmentRepository = new Lazy<IEnrollmentRepository>(() => new EnrollmentRepository(_repositoryContext));
            _courseAssignmentRepository = new Lazy<ICourseAssignmentRepository>(() => new CourseAssignmentRepository(_repositoryContext));
            _officeAssignmentRepository = new Lazy<IOfficeAssignmentRepository>(() => new OfficeAssignmentRepository(_repositoryContext));
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_repositoryContext));
        }


        public IStudentRepository Student => _studentRepository.Value;

        public ICourseRepository Course => _courseRepository.Value;

        public IInstructorRepository Instructor => _instructorRepository.Value;

        public IEnrollmentRepository Enrollment => _enrollmentRepository.Value;

        public ICourseAssignmentRepository CourseAssignment => _courseAssignmentRepository.Value;

        public IOfficeAssignmentRepository OfficeAssignment => _officeAssignmentRepository.Value;

        public IDepartmentRepository Department => _departmentRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
    }
}
