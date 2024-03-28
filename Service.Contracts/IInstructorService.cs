using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Service.Contracts
{
    public interface IInstructorService
    {
        IEnumerable<Instructor> GetAllInstructors(bool trackChanges);
    }
}
