using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;

namespace Repository
{
    public class OfficeAssignmentRepository : RepositoryBase<OfficeAssignment>, IOfficeAssignmentRepository
    {
        public OfficeAssignmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOfficeAssignment(OfficeAssignment officeAssignment) => Create(officeAssignment);


        public IEnumerable<OfficeAssignment> GetAllOfficeAssignments(bool trackChanges) => FindAll(trackChanges).OrderBy(oa => oa.Location).ToList();

        public OfficeAssignment GetOfficeAssignment(Guid instructorId, bool trackChanges) =>
            FindByCondition(oa => oa.InstructorId.Equals(instructorId), trackChanges).SingleOrDefault();
        
    }
}
