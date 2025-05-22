using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryConsole.Data;
using LMSTest.Data;

namespace LMSTest.Services
{
    public class StudentService
    {
        private readonly ApplicationDbContext context;
        public StudentService(ApplicationDbContext _context)
        {
            context = _context;
        }
        //------------
        public void AddStudent(string Name, string NATIONALID) 
        {
            var student = new Student
            {
                Name = Name
            ,
                NationalId = NATIONALID
            };
            context.Students.Add(student);
            context.SaveChanges();
            System.Console.WriteLine($"Student :{Name} Added");

        }
        //------------------------
        public void UpdateStudent(int Id, string Name, string NationalID )
        {
            var student = context.Students.Find(Id);
            if (student != null)
            {
                student.Name = Name;
                student.NationalId = NationalID;
                context.SaveChanges();
                System.Console.WriteLine($"Student:{Name} UPDATED ");
            }
            else System.Console.WriteLine($"Student with ID:{Id} NOT FOUND");

        }
        //-----------------------------
        public void DeleteStudent(int Id)
        {
            var student = context.Students.Find(Id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                System.Console.WriteLine("Student Removed");
            }
            else System.Console.WriteLine($"Student with ID:{Id} NOT FOUND");
        }
        //-----------------------
        public void ListAllStudents()
        {
            var students = context.Students.ToList();

            foreach (var student in students)
            {

                System.Console.WriteLine("HERE IS FULL STUDENTS LIST"); 
                System.Console.WriteLine($"ID:{student.Id} , Name:{student.Name}");

            }

        }
    }
}
