using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEnrollmentService
    {
        IEnumerable<EnrollmentDto> GetAllEnrollments(Guid studentId, bool trackChanges);
        EnrollmentDto GetEnrollment(Guid studentId, Guid id, bool trackChanges);
    }
}
