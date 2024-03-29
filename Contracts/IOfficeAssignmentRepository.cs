using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Contracts
{
    public interface IOfficeAssignmentRepository
    {
        IEnumerable<OfficeAssignment> GetAllOfficeAssignments(bool trackChanges);
        OfficeAssignment GetOfficeAssignment(Guid instructorId, bool trackChanges);
        void CreateOfficeAssignment(OfficeAssignment officeAssignment);
    }
}
