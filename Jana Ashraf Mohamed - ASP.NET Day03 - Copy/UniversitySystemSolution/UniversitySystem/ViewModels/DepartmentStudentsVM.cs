using System.Collections.Generic;

namespace UniversitySystem.ViewModels
{
    public class DepartmentStudentsVM
    {
        public string DepartmentName { get; set; }

        public List<string> StudentNames { get; set; }

        public string DepartmentState { get; set; }
    }
}