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

        public IEnumerable<Instructor> GetAllInstructors(bool trackChanges) => FindAll(trackChanges).OrderBy(s => s.LastName).ToList();
    }
}
