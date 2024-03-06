using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Controllers
{
    public class RegistrationController() : Controller
    {


        private readonly ApplicationDbContext _db;

        public object dbContext { get; private set; }

        public void RegisterController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult ShowAllCourses()
        {
            // Retrieve all courses from the database
            var courses = dbContext.Courses.ToList();
            return View(courses);
        }

        [HttpPost]
        public IActionResult Registration(int studentID, int CourseID)
        {
            // Check if the student has already registered for 3 courses
            var studentRegisteredCoursesCount = _db.Registrations
                                                .Count(r => r.StudentID == studentID);
            if (studentRegisteredCoursesCount >= 3)
            {
                // Return an error message or redirect to an error page indicating the student has reached the limit.
                return RedirectToAction("Error", "Home");
            }

            // Check if the course has reached the maximum registration limit
            var courseRegistrationsCount = _db.Registrations
                                            .Count(r => r.CourseID == CourseID);
            if (courseRegistrationsCount >= 5)
            {
                // Return an error message or redirect to an error page indicating the course has reached its registration limit.
                return RedirectToAction("Error", "Home");
            }

            // If validation passes, create a new registration record
            var registration = new Registrations { StudentID = studentID, CourseID = CourseID };
            _db.Registrations.Add(registration);
            _db.SaveChanges();

            return RedirectToAction("ShowAllCourses");
        }
        
    }



}



