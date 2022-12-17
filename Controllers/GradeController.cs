using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using platzi_school.Models;

namespace platzi_school.Controllers
{
    public class GradeController : Controller
    {
        // [Route("student/index")]
        // [Route("student/index/{id}")]
        public IActionResult Index(string id)
        {
            if(!string.IsNullOrWhiteSpace(id))
            {
                var grade = from gra
                            in _context.Grades
                            where gra.Id == id
                            select gra;
                return View(grade.SingleOrDefault());
            }
            else
            {
                return View("MultiGrade", _context.Grades);
            }
        }
        
        public IActionResult MultiGrade()
        {
            ViewBag.date = DateTime.Now;

            return View("MultiGrade", _context.Grades);
        }
        
        public IActionResult CreateGrade()
        {
            ViewBag.date = DateTime.Now;
            return View();
        }

        [HttpPost]
        public IActionResult CreateGrade(Grade grade)
        {
            ViewBag.date = DateTime.Now;

            var school = _context.Schools.FirstOrDefault();
            grade.SchoolId = school?.Id;

            _context.Grades.Add(grade);

            _context.SaveChanges();
            return View();
        }

        private SchoolContext _context;

        public GradeController(SchoolContext context)
        {
            _context = context;
        }
    }
}