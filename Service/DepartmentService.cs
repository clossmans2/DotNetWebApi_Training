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
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DepartmentService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public DepartmentDto CreateDepartment(DepartmentForCreationDto department)
        {
            var departmentEntity = _mapper.Map<Department>(department);
            var instructor = _repositoryManager.Instructor.GetInstructor(department.InstructorId.Value, false);
            if (instructor == null)
                throw new InstructorNotFoundException(department.InstructorId.Value);

            departmentEntity.Administrator = instructor;
            _repositoryManager.Department.CreateDepartment(departmentEntity);
            _repositoryManager.Save();
            var departmentToReturn = _mapper.Map<DepartmentDto>(departmentEntity);
            return departmentToReturn;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments(bool trackChanges)
        {
            var department = _repositoryManager.Department.GetAllDepartments(trackChanges);
            var departmentDto = _mapper.Map<IEnumerable<DepartmentDto>>(department);
            return departmentDto;
        }

        public DepartmentDto GetDepartment(Guid id, bool trackChanges)
        {
            var department = _repositoryManager.Department.GetDepartment(id, trackChanges);
            if (department == null)
                throw new DepartmentNotFoundException(id);

            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return departmentDto;
        }
    }
}
