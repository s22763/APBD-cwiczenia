using APBD3.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
            new Student{IdStudent=1, FirstName="Jan", LastName="Kowalski"},
            new Student{IdStudent=2, FirstName="Stefan", LastName="Walski"},
            new Student{IdStudent=3, FirstName="Alex", LastName="Starski"}
            };
        }

        public IEnumerable<Student> GetStudents(string orderBy)
        {
            if (orderBy == "name")
                _students.OrderBy(Student => Student.FirstName);
            if (orderBy == "surname")
                _students.OrderBy(Student => Student.LastName);
            if (orderBy == "index")
                return _students.OrderBy(Student => Student.IndexNumber);
            else return _students.OrderBy(Student => Student.IdStudent);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
            //throw new System.NotImplementedException();
        }

        public bool AddStudent(Student s)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteStudent(string i)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteStudent(Student i)
        {
            throw new System.NotImplementedException();
        }
      

        public void UpdateStudent(Student s)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteStudent(int i)
        {
            throw new System.NotImplementedException();
        }

        public Student GetStudent(int i)
        {
            foreach (Student student in _students)
            {
                if (student.IndexNumber == i) return student;
            }
            throw new System.NotImplementedException();
        }
    }
}
