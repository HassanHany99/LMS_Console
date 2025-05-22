using LibraryConsole.Data;
using Microsoft.EntityFrameworkCore;


namespace LMSTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=HASSAN;Database=LibraryDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Author>().HasMany(b => b.Books).
                WithOne(a => a.Author).HasForeignKey(b => b.AuthorId);
            //----------------------------------------//

            modelBuilder.Entity<Student>().HasMany(B => B.Borrows).
                WithOne(S => S.Student).HasForeignKey(B => B.StudentId);
            //----------------------------------------//
            modelBuilder.Entity<Book>().HasMany(B => B.Borrows).
                WithOne(S => S.Book).HasForeignKey(B => B.BookId); 

        }
    }
}
