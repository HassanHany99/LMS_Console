using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryConsole.Data;
using LMSTest.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace LMSTest.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext context;
        public BookService(ApplicationDbContext _context)
        {
             context = _context;
        }
        
        public void AddBook(string title , int authorId , DateTime publishDate) {

            bool AuthExist = context.Authors.Any( a => a.Id == authorId );
            if (!AuthExist) { 
                Console.WriteLine("Author not found. Please add the author first.");
                return;
            }
            var book = new Book { Title = title , AuthorId = authorId ,
            PublishedDate = publishDate};
            context.Books.Add(book);
            context.SaveChanges();
            Console.WriteLine($" The Book :{title} has been Added");
        }
       //-----------------------
        public void UpdateBook(int id , string title) { 
        var book = context.Books.Find(id);
            if (book != null)
            {
                book.Title = title;
                context.SaveChanges();
                Console.WriteLine($"Title has been Updated to: {title}");
            }
            else Console.WriteLine("Book Not Found");
        }
        //-----------------------
        public void DeleteBook(int id) { 
        var book =context.Books.Find(id);
            if (book != null) {
                context.Books.Remove(book);
                context.SaveChanges();
                Console.WriteLine($"Book ID:{id} Removed"); 
        }
            else Console.WriteLine("Book Not Found");
        }

        public void ListBooks()
        {
            var books = context.Books.Include( a => a.Author ).ToList();
            foreach (var book in books)
            {
                Console.WriteLine($"Book : {book.Title} , Author : {book.Author?.Name??"Unknown"}");
            }
        }

}
    }
