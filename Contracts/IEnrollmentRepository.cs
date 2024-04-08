using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetEnrollmentsForStudentAsync(Guid studentId, bool trackChanges);
        IEnumerable<Enrollment> GetAllEnrollments(Guid studentId, bool trackChanges);
        Enrollment GetEnrollment(Guid studentId, Guid id, bool trackChanges);

        void CreateEnrollment(Enrollment enrollment);
    }
}
