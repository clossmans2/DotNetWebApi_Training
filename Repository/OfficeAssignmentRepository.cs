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

        public IEnumerable<OfficeAssignment> GetAllOfficeAssignments(bool trackChanges) => FindAll(trackChanges).OrderBy(oa => oa.Location).ToList();

    }
}
