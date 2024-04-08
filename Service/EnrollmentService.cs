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
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EnrollmentService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public EnrollmentDto CreateEnrollment(EnrollmentForCreationDto enrollment)
        {
            var student = _repositoryManager.Student.GetStudent(enrollment.StudentId, false);
            if (student == null)
                throw new StudentNotFoundException(enrollment.StudentId);

            var course = _repositoryManager.Course.GetCourse(enrollment.CourseId, false);
            if (course == null)
                throw new CourseNotFoundException(enrollment.CourseId);

            var enrollmentEntity = _mapper.Map<Enrollment>(enrollment);
            enrollmentEntity.Student = student;
            enrollmentEntity.Course = course;
            _repositoryManager.Enrollment.CreateEnrollment(enrollmentEntity);
            _repositoryManager.Save();
            var enrollmentToReturn = _mapper.Map<EnrollmentDto>(enrollmentEntity);
            return enrollmentToReturn;            
        }

        public IEnumerable<EnrollmentDto> GetAllEnrollments(Guid studentId, bool trackChanges)
        {
            var student = _repositoryManager.Student.GetStudent(studentId, trackChanges);
            if (student == null)
                throw new StudentNotFoundException(studentId);

            var enrollments = _repositoryManager.Enrollment.GetAllEnrollments(studentId, trackChanges);
            var enrollmentsDto = _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);
            return enrollmentsDto;
        }

        public async Task<IEnumerable<EnrollmentDto>> GetAllEnrollmentsAsync(Guid studentId, bool trackChanges)
        {
            var enrollments = await _repositoryManager.Enrollment.GetEnrollmentsForStudentAsync(studentId, trackChanges);
            var enrollmentsDto = _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);
            return enrollmentsDto;
        }

        public EnrollmentDto GetEnrollment(Guid studentId, Guid id, bool trackChanges)
        {
            var student = _repositoryManager.Student.GetStudent(studentId, trackChanges);
            if (student == null)
                throw new StudentNotFoundException(studentId);

            var enrollment = _repositoryManager.Enrollment.GetEnrollment(studentId, id, trackChanges);
            if (enrollment == null)
                throw new EnrollmentNotFoundException(studentId, id);

            var enrollmentDto = _mapper.Map<EnrollmentDto>(enrollment);
            return enrollmentDto;
        }
    }
}
