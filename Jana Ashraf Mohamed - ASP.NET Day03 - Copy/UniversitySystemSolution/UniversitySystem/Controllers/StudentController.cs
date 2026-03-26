using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Data;
using System.Linq;

namespace UniversitySystem.Controllers
{
    public class StudentController : Controller
    {
        AppDbContext context;

        public StudentController(AppDbContext _context)
        {
            context = _context;
        }

        // /Student/ShowAll
        public IActionResult ShowAll()
        {
            var students = context.Students.ToList();
            return View(students);
        }

        // /Student/ShowDetails?id=3
        public IActionResult ShowDetails(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }
    }
}
