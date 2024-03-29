using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Student> GetAllStudents(bool trackChanges) => 
            FindAll(trackChanges).OrderBy(s => s.LastName).ToList();

        public Student GetStudent(Guid studentId, bool trackChanges) => 
            FindByCondition(s => s.Id.Equals(studentId), trackChanges).SingleOrDefault();

        public void CreateStudent(Student student) => Create(student);

        public void DeleteStudent(Student student) => Delete(student);

        public async Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.LastName)
                .ToListAsync();
                


        public async Task<Student> GetStudentAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
                .SingleOrDefaultAsync();

    }
}
