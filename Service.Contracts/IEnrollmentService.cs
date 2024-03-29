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
        Task<IEnumerable<EnrollmentDto>> GetAllEnrollmentsAsync(Guid studentId, bool trackChanges);
        IEnumerable<EnrollmentDto> GetAllEnrollments(Guid studentId, bool trackChanges);
        EnrollmentDto GetEnrollment(Guid studentId, Guid id, bool trackChanges);
        EnrollmentDto CreateEnrollment(EnrollmentForCreationDto enrollment);
    }
}
