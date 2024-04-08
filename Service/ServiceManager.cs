using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStudentService> _studentService;
        private readonly Lazy<ICourseService> _courseService;
        private readonly Lazy<IInstructorService> _instructorService;
        private readonly Lazy<IDepartmentService> _departmentService;
        private readonly Lazy<IOfficeAssignmentService> _officeAssignmentService;
        private readonly Lazy<ICourseAssignmentService> _courseAssignmentService;
        private readonly Lazy<IEnrollmentService> _enrollmentService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper,
            UserManager<User> userManager,
            IOptions<JwtConfiguration> configuration)
        {
            _studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager, logger, mapper));
            _courseService = new Lazy<ICourseService>(() => new CourseService(repositoryManager, logger, mapper));
            _instructorService = new Lazy<IInstructorService>(() => new InstructorService(repositoryManager, logger, mapper));
            _departmentService = new Lazy<IDepartmentService>(() => new DepartmentService(repositoryManager, logger, mapper));
            _officeAssignmentService = new Lazy<IOfficeAssignmentService>(() => new OfficeAssignmentService(repositoryManager, logger, mapper));
            _courseAssignmentService = new Lazy<ICourseAssignmentService>(() => new CourseAssignmentService(repositoryManager, logger, mapper));
            _enrollmentService = new Lazy<IEnrollmentService>(() => new EnrollmentService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
        }

        public IStudentService Student => _studentService.Value;
        public ICourseService Course => _courseService.Value;
        public IInstructorService Instructor => _instructorService.Value;
        public IDepartmentService Department => _departmentService.Value;
        public IOfficeAssignmentService OfficeAssignment => _officeAssignmentService.Value;
        public ICourseAssignmentService CourseAssignment => _courseAssignmentService.Value;
        public IEnrollmentService Enrollment => _enrollmentService.Value;
        public IAuthenticationService Authentication => _authenticationService.Value;

    }
}
