using APBD3.Models;
using System.Collections.Generic;

namespace WebApplication.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
        public IEnumerable<Student> GetStudents(string orderBy);

        public void UpdateStudent(Student s);
        public void DeleteStudent(int i);
        public void DeleteStudent(Student i);
        public Student GetStudent(int i);
        public bool AddStudent(Student s);
        //void DeleteStudent(string id);
    }
}
