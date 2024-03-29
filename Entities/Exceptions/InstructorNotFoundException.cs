using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class InstructorNotFoundException : NotFoundException
    {
        public InstructorNotFoundException(Guid instructorId) 
            : base($"The instructor with the id: {instructorId} doesn't exist in the database.")
        {
            
        }
    }
}
