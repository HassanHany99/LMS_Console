using LMSTest.Data;

using LibraryConsole.Data;
using Microsoft.EntityFrameworkCore;

namespace LMSTest.Services
{
    public class AuthorService
    {
        private readonly ApplicationDbContext context;
        public AuthorService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void AddAuthor(string name)
        {

            {
                var author = new Author
                {
                    Name = name
                };
                context.Authors.Add(author);
                context.SaveChanges();
                System.Console.WriteLine($"Author :{name} Added");

            }

        }
        //ـــــــــــــــــــــــــــــــــــــــــــــ

        public string FindAuthor(int id)
        {

            var author = context.Authors.Find(id);
            return author?.Name ?? "Author Not Found";
        }
        //ـــــــــــــــــــــــــــــــــــــــــــــ

        public void DeleteAuthor(int id)
        {
            var author = context.Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                context.Authors.Remove(author);
                context.SaveChanges();
                System.Console.WriteLine($"Author No:{id} Deleted");
            }
            else
                System.Console.WriteLine("Author NOT Found");

        }
        //ـــــــــــــــــــــــــــــــــــــــــــــ
        public void UpdateAuthor(int id, string name)
        {

            var author = context.Authors.Find(id);
            if (author != null)
            {
                author.Name = name;
                context.SaveChanges();
                System.Console.WriteLine("Name Changed");
            }
            else System.Console.WriteLine("Author NOT Found");

        }
        //ـــــــــــــــــــــــــــــــــــــــــــــ
        public void ListAuhtors()
        {
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                System.Console.WriteLine("author.Name");
            }


        }
    }
}
