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
    public class OfficeAssignmentService : IOfficeAssignmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public OfficeAssignmentService(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public IEnumerable<OfficeAssignment> GetAllOfficeAssignments(bool trackChanges) =>
            _repositoryManager.OfficeAssignment.GetAllOfficeAssignments(trackChanges);
    }
}
