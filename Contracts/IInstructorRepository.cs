using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IInstructorRepository
    {
        IEnumerable<Instructor> GetAllInstructors(bool trackChanges);
        Instructor GetInstructor(Guid instructorId, bool trackChanges);
        void CreateInstructor(Instructor instructor);
    }
}
