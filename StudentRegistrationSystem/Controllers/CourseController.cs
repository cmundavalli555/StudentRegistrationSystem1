using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;

        // GET: Course
        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }
        


        public IActionResult Index()
        {
            List<Courses> objCourseList = _db.Courses.ToList();
            return View(objCourseList);
        }
        //Create action method
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Courses course)
        {
            if (course.CourseName == course.ToString())
            {
                ModelState.AddModelError("Coursename", "coursename not match format");
            }
            if (ModelState.IsValid)
            {
                _db.Courses.Add(course);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }


            return View();
        }

        [HttpGet]

        public IActionResult Edit()
        {
            return View();
        }


        public IActionResult Edit(int? CourseID)
        {

            if (CourseID == null || CourseID == 0)
            {
                return NotFound();
            }


            Courses? courseFromDb = _db.Courses.Find(CourseID);
            //Course? courseFromDb1 = _db.Courses.FirstOrDefault(u=> u.CourseID == CourseID);
            //Course? courseFromDb2 = _db.Courses.Where(u => u.CourseID == CourseID).FirstOrDefault();

            if (courseFromDb == null)
            {
                return NotFound();
            }

            return View(courseFromDb);

        }
        [HttpPost]
        public IActionResult Edit(Courses course)
        {
            _db.Courses.Update(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete() 
        { 
            return View(); 
        }

        public IActionResult Delete(int? CourseID)
        {
            var getDeleteForm = _db.Students.Find(CourseID);
            return View(getDeleteForm);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePostData(int? CourseID)
        {
            Students? getDeleteForm = _db.Students.Find(CourseID);
            if (getDeleteForm != null)
            {
                _db.Students.Remove(getDeleteForm);
                _db.SaveChanges();
            }
            return View(getDeleteForm);


        }
    }
}

