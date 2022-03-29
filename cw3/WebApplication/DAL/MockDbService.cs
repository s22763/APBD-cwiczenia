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
            if (orderBy == "name") return _students.OrderBy(Student => Student.FirstName);
            if (orderBy == "surname") return _students.OrderBy(Student => Student.LastName);
            if (orderBy == "index") return _students.OrderBy(Student => Student.IndexNumber);
            else return _students.OrderBy(Student => Student.IdStudent);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
            //throw new System.NotImplementedException();
        }

        public Student GetStudent(int i)
        {
            foreach (Student student in _students)
            {
                if (student.IdStudent == i) return student;
            }
            throw new System.NotImplementedException();
        }

        public bool AddStudent(Student s)
        {
            if ( s != null )
            {
                _students.Append(s); 
                return true;
            }
            
            throw new System.NotImplementedException();
        }

        public void DeleteStudent(int i)
        {
            _students = _students.Where(u => u.IdStudent != i).ToList();
            throw new System.NotImplementedException();
        }

        public void DeleteStudent(Student s)
        {
            if (s != null) {
                _students = _students.Where(x => x != s).ToList();
            } else throw new System.NotImplementedException();
        }
      

        public void UpdateStudent(Student s)
        {
            if (s != null)
            {
                Student s1 = _students.First(x => x.IdStudent == s.IdStudent);
                s1.LastName = "updated";
                _students = _students.Where(y => y.IdStudent != s.IdStudent).ToList();
                _students.Append(s1);
            }
            else throw new System.NotImplementedException();
        }

        
    }
}

