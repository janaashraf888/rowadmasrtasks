using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Borrower
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime MembershipDate { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
