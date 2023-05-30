using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Data;
using StudentInformationSystem.ViewModels;
using StudentInformationSystem.Models;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace StudentInformationSystem.Controllers
{
    [Route("api/v1/studentInfoSys")]
    [ApiController]
    public class StudentInformationSystemController : Controller
    {
        private StudentInformationDBContext _dBContext;

        public StudentInformationSystemController(StudentInformationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet]
        [Route("students")]
        public IActionResult GetAllStudents()
        {
            var students = _dBContext.Students.ToList();
            if (students.Count > 0)
            {
                return Ok(students);
            }
            return Ok("No records!");
        }

        [HttpGet]
        [Route("students/{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _dBContext.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student != null)
            {
                return Ok(student);     
            }
            return Ok("Record not found!");
        }

        [HttpPost]
        [Route("students/add")]
        public IActionResult AddStudent(StudentViewModel model)
        {
            var student = new Student()
            {
                Name = model.Name,
                EmailAddress = model.EmailAddress,
                ContactInformation = model.ContactInformation,
            };
            _dBContext.Students.Add(student);
            _dBContext.SaveChangesAsync();

            return Ok();
        }
        
        [HttpPut]
        [Route("students/{id}")]
        public IActionResult UpdateStudent(int id, StudentViewModel model)
        {
            var student = _dBContext.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            student.Name = model.Name;
            student.EmailAddress = model.EmailAddress;
            student.ContactInformation = model.ContactInformation;
            _dBContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("students/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _dBContext.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            _dBContext.Students.Remove(student);
            _dBContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        [Route("courses")]
        public IActionResult GetAllCourses()
        { 
            var courses = _dBContext.Courses.ToList();
            if (courses.Count > 0)
            {
                return Ok(courses);
            }
            return Ok("No records!");
        }

        [HttpGet]
        [Route("courses/{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = _dBContext.Courses.Where(x => x.Id == id).FirstOrDefault();
            if (course != null)
            {
                return Ok(course);
            }
            return Ok("No records!");
        }

        [HttpPost]
        [Route("courses/add")]
        public IActionResult AddCourse(CourseViewModel model)
        {
            var course = new Course()
            
            {
                Name = model.Name,
                Description = model.Description,
                Schedule = model.Schedule
            };
            _dBContext.Courses.Add(course);
            _dBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("courses/{id}")]
        public IActionResult UpdateCourse(int id, CourseViewModel model)
        {
            var course = _dBContext.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            course.Name = model.Name;
            course.Description = model.Description;
            course.Schedule = model.Schedule;
            _dBContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("courses/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var student = _dBContext.Courses.Where(x => x.Id == id).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            _dBContext.Courses.Remove(student);
            _dBContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        [Route("enrollments/add")]
        public IActionResult AddEnrollment(EnrollmentViewModel model)
        {  
            var enrollment = new Enrollment
            {
                StudentID = model.StudentID,
                CourseID = model.CourseID,
                Grade = model.Grade
            };
            _dBContext.Enrollments.Add(enrollment);
            _dBContext.SaveChangesAsync();
            return Ok();
        }
        
        [HttpGet]
        [Route("enrollments")]
        public IActionResult GetAllEnrollments()
        {
            var enrollments = _dBContext.Enrollments.Include(x => x.Student).Include(y => y.Course).ToList();
            
            if (enrollments.Count > 0)
            {
                return Ok(enrollments);
            }
            return Ok("No records!");
        }

        [HttpGet]
        [Route("enrollments/{id}")]
        public IActionResult GetEnrollment(int id)
        {
            var enrollment = _dBContext.Enrollments.Where(x => x.Id == id).FirstOrDefault();
            if (enrollment != null)
            {
                return Ok(enrollment);
            }
            return Ok("No record!");
        }

        [HttpPut]
        [Route("enrollments/{id}")]
        public IActionResult UpdateEnrollment(int id, EnrollmentViewModel model)
        {
            var enrollment = _dBContext.Enrollments.Find(id);
            if (enrollment ==  null)
            {
                return NotFound();
            }
            enrollment.CourseID = model.CourseID;
            enrollment.StudentID = model.StudentID;
            _dBContext.SaveChangesAsync();
            return NoContent();
        }
    }
}   