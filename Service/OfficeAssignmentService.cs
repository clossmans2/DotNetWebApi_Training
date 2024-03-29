using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class OfficeAssignmentService : IOfficeAssignmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public OfficeAssignmentService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<OfficeAssignmentDto> GetAllOfficeAssignments(bool trackChanges)
        {
            var officeAssignments = _repositoryManager.OfficeAssignment.GetAllOfficeAssignments(trackChanges);
            var officeAssignmentsDto = _mapper.Map<IEnumerable<OfficeAssignmentDto>>(officeAssignments);
            return officeAssignmentsDto;
        }

        public OfficeAssignmentDto GetOfficeAssignment(Guid instructorId, bool trackChanges)
        {
            var officeAssignment = _repositoryManager.OfficeAssignment.GetOfficeAssignment(instructorId, trackChanges);
            if (officeAssignment == null)
                throw new OfficeAssignmentNotFoundException(instructorId);

            var officeAssignmentDto = _mapper.Map<OfficeAssignmentDto>(officeAssignment);
            return officeAssignmentDto;
        }

        public OfficeAssignmentDto CreateOfficeAssignment(OfficeAssignmentDto officeAssignment)
        {
            var officeAssignmentEntity = _mapper.Map<OfficeAssignment>(officeAssignment);
            var instructor = _repositoryManager.Instructor.GetInstructor(officeAssignmentEntity.InstructorId, false);
            if (instructor == null)
                throw new InstructorNotFoundException(officeAssignmentEntity.InstructorId);

            officeAssignmentEntity.Instructor = instructor;
            _repositoryManager.OfficeAssignment.CreateOfficeAssignment(officeAssignmentEntity);
            _repositoryManager.Save();
            var officeAssignmentToReturn = _mapper.Map<OfficeAssignmentDto>(officeAssignmentEntity);
            return officeAssignmentToReturn;
        }
    }
}
