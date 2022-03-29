using APBD3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication.DAL;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents(orderBy));
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
             return Ok(_dbService.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int i)
        {
            Student st = _dbService.GetStudent(i);
            if (st != null) return Ok (st);
            //{
            //    return Ok("Kowalski");
            //}
            //else if (id == 2) {
            //    return Ok("Malejeski");
            //}
          else return NotFound("Nie znaleziono studenta");
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (student != null) { 
                student.IndexNumber = $"s{new Random().Next(1, 20000)}";
                return Ok(_dbService.AddStudent(student));
            }
            else return NotFound("Nie znaleziono studenta");
        }

        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            if (student != null) { 
                _dbService.UpdateStudent(student);
                return Ok(student);
            } else return NotFound("Nie znaleziono studenta");
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int i)
        {
                _dbService.DeleteStudent(i);
                return Ok("Delete complete");
        }

        [HttpDelete]
        public IActionResult DeleteStudent([FromBody] Student student)
        {
            if (student != null)
            {
                _dbService.DeleteStudent(student);
                return Ok("Student zostal usuniety");
            }
            else return NotFound("Nie znaleziono studenta");
        }

    }
}
