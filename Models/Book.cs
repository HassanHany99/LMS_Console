using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsole.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishedDate { get; set; }
        public Author Author { get; set; }
        public List<Borrow> Borrows { get; set; } = new List<Borrow>();
    }
}
