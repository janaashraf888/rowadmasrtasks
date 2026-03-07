using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
