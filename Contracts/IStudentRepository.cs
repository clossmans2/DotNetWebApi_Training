using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges);
        Task<Student> GetStudentAsync(Guid studentId, bool trackChanges);

        IEnumerable<Student> GetAllStudents(bool trackChanges);
        Student GetStudent(Guid studentId, bool trackChanges);
        void CreateStudent(Student student);
        void DeleteStudent(Student student);
    }
}
