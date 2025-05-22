using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryConsole.Data;
using LMSTest.Data;
using Microsoft.EntityFrameworkCore;
namespace LMSTest.Services
{
    public class BorrowService
    {
        private readonly ApplicationDbContext context;

        public BorrowService(ApplicationDbContext _context)
        {
            context = _context;
        }
        //----------------
        public void AddBorrow(int studentId, int bookId)
        {
            bool stdExist = context.Students.Any(s => s.Id == studentId);
            bool bokExist = context.Books.Any(b => b.Id == bookId);
            if (!stdExist || !bokExist)
            {
                Console.WriteLine("Student or Book not found. Please check IDs.");
                return;
            }
                var borrow = new Borrow
                {
                    StudentId = studentId,
                    BookId = bookId,
                    BorrowDate = DateTime.Now
                };
                context.Borrows.Add(borrow);
            context.SaveChanges();
                Console.WriteLine("Book borrowed successfully.");
        }
        //----------------------------
        public void ReturnBook(int borrowId)
        {
            var borrow = context.Borrows.Find(borrowId);
            if (borrow == null)
            {
                Console.WriteLine("Borrow record not found.");
                return;
            }
            if (borrow.ReturnDate != null)
            {
                Console.WriteLine("This Book Already returned");
                return;
            }
            borrow.ReturnDate = DateTime.Now;
            context.SaveChanges();
            Console.WriteLine("Book returned successfully.");
        }
        //----------------------------
        public void ListAllBorrows() { 
        var BorrowsList = context.Borrows.
                Include(a => a.Student)
                .Include(b => b.Book).ToList();
            foreach ( var borrow in BorrowsList)
            {
                  string ReturnSTAT = borrow.ReturnDate.HasValue
                    ? $"Returned in :{borrow.ReturnDate}" : "Not Returned";
                Console.WriteLine($"Student :{borrow.Student.Name} , Book :{borrow.Book.Title} " +
                    $", Borrowd in :{borrow.BorrowDate} ,Returned in {ReturnSTAT} ");
            }
        }
    }
}
