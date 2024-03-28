using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StudentNotFoundException : NotFoundException
    {
        public StudentNotFoundException(Guid studentId) : base($"The student with the id: {studentId} doesn't exist in the database.")
        {
        }
    }
}
