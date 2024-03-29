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
    public class InstructorService : IInstructorService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public InstructorService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public InstructorDto CreateInstructor(InstructorForCreationDto instructor)
        {
            var instructorEntity = _mapper.Map<Instructor>(instructor);
            _repositoryManager.Instructor.CreateInstructor(instructorEntity);
            _repositoryManager.Save();
            var instructorToReturn = _mapper.Map<InstructorDto>(instructorEntity);
            return instructorToReturn;
        }


        public IEnumerable<InstructorDto> GetAllInstructors(bool trackChanges)
        {
            var instructors = _repositoryManager.Instructor.GetAllInstructors(trackChanges);
            var instructorsDto = _mapper.Map<IEnumerable<InstructorDto>>(instructors);
            return instructorsDto;
        }
    

        public InstructorDto GetInstructor(Guid id, bool trackChanges)
        {
            var instructor = _repositoryManager.Instructor.GetInstructor(id, trackChanges);
            if (instructor == null)
                throw new InstructorNotFoundException(id);

            var instructorDto = _mapper.Map<InstructorDto>(instructor);
            return instructorDto;
        }
    }
}
