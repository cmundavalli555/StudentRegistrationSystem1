using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Controllers
{
    public class AdminController1 : Controller
    {
        // GET: AdminController1
        private readonly ApplicationDbContext _db;

        // GET: Course
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            return View();
        }

        
        public IActionResult AdminPage()
        {
            var coursesWithRegistrations = _db.Courses
                                            .Select(c => new
                                            {
                                                Course = c,
                                                RegistrationCount = c.Registrations.Count()
                                            })
                                            .ToList();
            return View(coursesWithRegistrations);
        }


        // GET: AdminController1/Create

    }
}
