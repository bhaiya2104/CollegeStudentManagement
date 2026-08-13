



using CollegeStudentManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CollegeStudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly DatabaseContext db;

        public StudentController(DatabaseContext db)
        {
            this.db = db;
        }




        //index
        public IActionResult Index(string search)
        {
            var students = db.Students.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(s => s.Name.Contains(search));
            }

            return View(students.ToList());
        }

        //profile
        public IActionResult Profile()
        {
            return View();
            return RedirectToAction("Index","Student");
        }


        //login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login
            login)
        {
            var data = db.Logins.FirstOrDefault(x => x.Username
            == login.Username && x.Password == login.Password);
            if (data != null)
                
            {
                TempData["Success"] = "Login Succesful";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Invalid username or password";
                return View();

            }
        }




        //create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid) { 
            return View(student);
                    }
            db.Students.Add(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        //edit
        public IActionResult Edit(int id)
        {
            var student = db.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }





        //delete
        public IActionResult Delete(int id)
        {
            var student = db.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int StudentId)
        {
            var student = db.Students.Find(StudentId);

            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }





        //details
        public IActionResult Details(int id)
        {
            var student = db.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}