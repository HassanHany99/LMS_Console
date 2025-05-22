using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsole.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public List<Borrow> Borrows { get; set; } = new List<Borrow>();

    }
}
