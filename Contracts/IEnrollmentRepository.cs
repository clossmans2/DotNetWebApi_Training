using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Contracts
{
    public interface IEnrollmentRepository
    {
        IEnumerable<Enrollment> GetAllEnrollments(Guid studentId, bool trackChanges);
        Enrollment GetEnrollment(Guid studentId, Guid id, bool trackChanges);

        void CreateEnrollment(Enrollment enrollment);
    }
}
