using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEnrollment(Enrollment enrollment) => Create(enrollment);

        public IEnumerable<Enrollment> GetAllEnrollments(Guid studentId, bool trackChanges) => 
            FindByCondition(e => e.StudentId.Equals(studentId), trackChanges).ToList();

        public Enrollment GetEnrollment(Guid studentId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.StudentId.Equals(studentId) && e.Id.Equals(id), trackChanges).SingleOrDefault();

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsForStudentAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(e => e.StudentId.Equals(studentId), trackChanges).ToListAsync();
        
    }
}
