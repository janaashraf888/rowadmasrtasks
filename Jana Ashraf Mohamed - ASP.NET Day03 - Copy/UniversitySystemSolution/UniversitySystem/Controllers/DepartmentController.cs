using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversitySystem.Data;
using UniversitySystem.Models;
using UniversitySystem.ViewModels;

namespace UniversitySystem.Controllers
{
    public class DepartmentController : Controller
    {
        AppDbContext context;

        public DepartmentController(AppDbContext _context)
        {
            context = _context;
        }

        public IActionResult ShowAll()
        {
            var departments = context.Departments.ToList();
            return View(departments);
        }
        public IActionResult ShowDetails(int id)
        {
            var dept = context.Departments.FirstOrDefault(d => d.Id == id);

            return View(dept);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department dept)
        {
            context.Departments.Add(dept);
            context.SaveChanges();

            return RedirectToAction("ShowAll");
        }
        public IActionResult DepartmentStudents(int id)
        {
            var dept = context.Departments.FirstOrDefault(d => d.Id == id);

            var students = context.Students
                .Where(s => s.DepartmentId == id && s.Age > 25)
                .Select(s => s.Name)
                .ToList();

            int totalStudents = context.Students
                .Count(s => s.DepartmentId == id);

            string state = totalStudents > 50 ? "Main" : "Branch";

            var vm = new DepartmentStudentsVM
            {
                DepartmentName = dept.Name,
                StudentNames = students,
                DepartmentState = state
            };

            return View(vm);
        }
    }
}
