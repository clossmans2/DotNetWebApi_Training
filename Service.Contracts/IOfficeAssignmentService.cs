using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IOfficeAssignmentService
    {
        IEnumerable<OfficeAssignmentDto> GetAllOfficeAssignments(bool trackChanges);
        OfficeAssignmentDto GetOfficeAssignment(Guid instructorId, bool trackChanges);
        OfficeAssignmentDto CreateOfficeAssignment(OfficeAssignmentDto officeAssignment);

    }
}
