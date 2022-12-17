using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using platzi_school.Models;

namespace platzi_school.Controllers
{
    public class StudentController : Controller
    {
        // [Route("student/index")]
        // [Route("student/index/{id}")]
        public IActionResult Index(string id)
        {
            if(!string.IsNullOrWhiteSpace(id))
            {
                var student = from stu
                            in _context.Students
                            where stu.Id == id
                            select stu;
                return View(student.SingleOrDefault());
            }
            else
            {
                return View("MultiStudent", _context.Students);
            }
        }
        
        public IActionResult MultiStudent()
        {
            ViewBag.date = DateTime.Now;

            return View("MultiStudent", _context.Students);
        }

        private SchoolContext _context;

        public StudentController(SchoolContext context)
        {
            _context = context;
        }
    }
}