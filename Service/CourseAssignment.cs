using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Service.Contracts;

namespace Service
{
    public class CourseAssignmentService : ICourseAssignmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public CourseAssignmentService(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public IEnumerable<CourseAssignment> GetAllCourseAssignments(bool trackChanges) =>
            _repositoryManager.CourseAssignment.GetAllCourseAssignments(trackChanges);
    }
}
