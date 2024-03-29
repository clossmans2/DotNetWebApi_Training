using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;

namespace Repository
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateDepartment(Department department) => Create(department);

        public IEnumerable<Department> GetAllDepartments(bool trackChanges) => 
            FindAll(trackChanges).OrderBy(s => s.Name).ToList();

        public Department GetDepartment(Guid id, bool trackChanges) =>
            FindByCondition(d => d.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
