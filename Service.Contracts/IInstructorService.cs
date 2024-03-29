using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IInstructorService
    {
        IEnumerable<InstructorDto> GetAllInstructors(bool trackChanges);
        InstructorDto GetInstructor(Guid id, bool trackChanges);
        InstructorDto CreateInstructor(InstructorForCreationDto instructor);

    }
}
