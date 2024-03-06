using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Controllers
{
    public class StudentController : Controller
    {
            private readonly ApplicationDbContext _db;

            public StudentController(ApplicationDbContext db)
            {
                _db = db;
            }

            public IActionResult Index()
            {
                List<Students> objStudentsList = _db.Students.ToList();
                return View(objStudentsList);
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Students student)
            {
                var students = _db.Students.Add(student);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            public IActionResult Edit()
            {
                return View();
            }



            public IActionResult Edit(int? StudentID)
            {
                var getEditForm = _db.Students.Find(StudentID);
                if (getEditForm == null)
                {
                    return NotFound();
                }
                return View(getEditForm);

            }
            [HttpPost]
            public IActionResult Edit(Students student)
            {
                _db.Students.Update(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            public IActionResult Delete()
            {
                 return View();
            }

            public IActionResult Delete(int? StudentID)
            {
                var getDeleteForm = _db.Students.Find(StudentID);
                return View(getDeleteForm);

            }
            [HttpPost, ActionName("Delete")]
            public IActionResult DeletePostData(int? StudentID)
            {
                Students? getDeleteForm = _db.Students.Find(StudentID);
                if (getDeleteForm != null)
                {
                    _db.Students.Remove(getDeleteForm);
                    _db.SaveChanges();
                }
                return View(getDeleteForm);


            }
        }
    }



