using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Loan
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int BorrowerId { get; set; }

        public Borrower Borrower { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
