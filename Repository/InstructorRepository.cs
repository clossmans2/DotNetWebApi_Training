using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Contracts;

namespace Repository
{
    public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository
    {
        public InstructorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Instructor> GetAllInstructors(bool trackChanges) => 
            FindAll(trackChanges).OrderBy(s => s.LastName).ToList();

        public void CreateInstructor(Instructor instructor) => Create(instructor);

        public Instructor GetInstructor(Guid instructorId, bool trackChanges) =>
            FindByCondition(i => i.Id.Equals(instructorId), trackChanges).SingleOrDefault();

    }
}
