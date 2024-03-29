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
    public class CourseAssignmentService : ICourseAssignmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CourseAssignmentService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public CourseAssignmentDto CreateCourseAssignment(CourseAssignmentDto courseAssignment)
        {
            var courseAssignmentEntity = _mapper.Map<CourseAssignment>(courseAssignment);
            var course = _repositoryManager.Course.GetCourse(courseAssignmentEntity.CourseId, false);
            if (course == null)
                throw new CourseNotFoundException(courseAssignmentEntity.CourseId);
            var instructor = _repositoryManager.Instructor.GetInstructor(courseAssignmentEntity.InstructorId, false);
            if (instructor == null)
                throw new InstructorNotFoundException(courseAssignmentEntity.InstructorId);
            courseAssignmentEntity.Course = course;
            courseAssignmentEntity.Instructor = instructor;
            _repositoryManager.CourseAssignment.CreateCourseAssignment(courseAssignmentEntity);
            var courseAssignmentToReturn = _mapper.Map<CourseAssignmentDto>(courseAssignmentEntity);
            return courseAssignmentToReturn;
            
        }

        public IEnumerable<CourseAssignmentDto> GetAllCourseAssignments(bool trackChanges)
        {
            var courseAssignments = _repositoryManager.CourseAssignment.GetAllCourseAssignments(trackChanges);
            var courseAssignmentsDto = _mapper.Map<IEnumerable<CourseAssignmentDto>>(courseAssignments);
            return courseAssignmentsDto;
        }
            

        public CourseAssignmentDto GetCourseAssignment(Guid courseId, Guid instructorId, bool trackChanges)
        {
            var courseAssignment = _repositoryManager.CourseAssignment.GetCourseAssignment(courseId, instructorId, trackChanges);
            if (courseAssignment == null)
                throw new CourseAssignmentNotFoundException(courseId, instructorId);

            var courseAssignmentDto = _mapper.Map<CourseAssignmentDto>(courseAssignment);
            return courseAssignmentDto;
        }

        public IEnumerable<CourseAssignmentDto> GetCourseAssignmentsByCourseId(Guid courseId, bool trackChanges)
        {
            var courseAssignments = _repositoryManager.CourseAssignment.GetCourseAssignmentsByCourseId(courseId, trackChanges);
            var courseAssignmentsDto = _mapper.Map<IEnumerable<CourseAssignmentDto>>(courseAssignments);
            return courseAssignmentsDto;
        }

        public IEnumerable<CourseAssignmentDto> GetCourseAssignmentsByInstructorId(Guid instructorId, bool trackChanges)
        {
            var courseAssignments = _repositoryManager.CourseAssignment.GetCourseAssignmentsByInstructorId(instructorId, trackChanges);
            var courseAssignmentsDto = _mapper.Map<IEnumerable<CourseAssignmentDto>>(courseAssignments);
            return courseAssignmentsDto;
        }
    }
}
