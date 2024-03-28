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
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public EnrollmentService(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public IEnumerable<Enrollment> GetAllEnrollments(bool trackChanges) =>
            _repositoryManager.Enrollment.GetAllEnrollments(trackChanges);
    }
}
