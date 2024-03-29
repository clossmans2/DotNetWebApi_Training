using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDto> GetAllDepartments(bool trackChanges);
        DepartmentDto GetDepartment(Guid id, bool trackChanges);
        DepartmentDto CreateDepartment(DepartmentForCreationDto department);

    }
}
