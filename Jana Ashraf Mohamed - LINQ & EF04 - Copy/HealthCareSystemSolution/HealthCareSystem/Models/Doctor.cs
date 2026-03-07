using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
