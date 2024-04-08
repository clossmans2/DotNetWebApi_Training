using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments(bool trackChanges);
        Department GetDepartment(Guid id, bool trackChanges);
        void CreateDepartment(Department department);
    }
}
