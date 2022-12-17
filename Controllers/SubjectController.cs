using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using platzi_school.Models;

namespace platzi_school.Controllers
{
    public class SubjectController : Controller
    {
        [Route("Subject/Index")]
        [Route("Subject/Index/{subjectId}")]
        public IActionResult Index(string subjectId)
        {
            if(!string.IsNullOrWhiteSpace(subjectId))
            {
                var subject = from sub
                            in _context.Subjects
                            where sub.Id == subjectId
                            select sub;
                return View(subject.SingleOrDefault());
            }
            else
            {
                return View("MultiSubject", _context.Subjects);
            }

        }
        
        public IActionResult MultiSubject()
        {
            ViewBag.date = DateTime.Now;

            return View("MultiSubject", _context.Subjects);

        }

        private SchoolContext _context;

        public SubjectController(SchoolContext context)
        {
            _context = context;
        }
    }
}