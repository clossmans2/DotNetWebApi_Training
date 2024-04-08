using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class CourseService : ICourseService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CourseService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public CourseDto CreateCourse(CourseForCreationDto course)
        {
            var courseEntity = _mapper.Map<Course>(course);
            var department = _repositoryManager.Department.GetDepartment(course.DepartmentId, false);
            if (department == null)
                throw new DepartmentNotFoundException(course.DepartmentId);
            
            courseEntity.Department = department;
            _repositoryManager.Course.CreateCourse(courseEntity);
            _repositoryManager.Save();
            var courseToReturn = _mapper.Map<CourseDto>(courseEntity);
            return courseToReturn;
        }

        public IEnumerable<CourseDto> GetAllCourses(bool trackChanges)
        {
            var courses = _repositoryManager.Course.GetAllCourses(trackChanges);
            var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return coursesDto;
        }

        public CourseDto GetCourse(Guid id, bool trackChanges)
        {
            var course = _repositoryManager.Course.GetCourse(id, trackChanges);
            if (course == null)
                throw new CourseNotFoundException(id);

            var courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }
    }
}
