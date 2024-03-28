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
    public class InstructorService : IInstructorService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public InstructorService(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public IEnumerable<Instructor> GetAllInstructors(bool trackChanges) =>
            _repositoryManager.Instructor.GetAllInstructors(trackChanges);
    }
}
