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
            School school = new School()
            {
                Name = "Platzi",
                SchoolId = Guid.NewGuid().ToString(),
                FoundationYear = 2005
            };
            
            ViewBag.cosaDinamica = "Espigator";

            return View(school);

        }
    }
}