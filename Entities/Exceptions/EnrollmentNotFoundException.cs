using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class EnrollmentNotFoundException : NotFoundException
    {
        public EnrollmentNotFoundException(Guid studentId, Guid id)
            : base($"The enrollment with the id: {id} doesn't exist for the student with id: {studentId}.")
        {
        }
    }
}
