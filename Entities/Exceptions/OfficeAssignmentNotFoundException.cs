using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class OfficeAssignmentNotFoundException : NotFoundException
    {
        public OfficeAssignmentNotFoundException(Guid instructorId) 
            : base($"The Office Assignment with the id: {instructorId} could not be found in the database.")
        {
        }
    }
}
