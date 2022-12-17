using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using platzi_school.Models;

namespace platzi_school.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.cosaDinamica = "Espigator";
            var school = _context.Schools.FirstOrDefault();
            return View(school);
        }

        private SchoolContext _context;

        public SchoolController(SchoolContext context)
        {
            _context = context;
        }
    }
}