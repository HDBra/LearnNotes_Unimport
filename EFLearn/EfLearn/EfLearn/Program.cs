using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfLearn.Utils;

namespace EfLearn
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var dbContext = new SchoolContext())
            {
                Student student = new Student(){StudentName = "Steve"};
                dbContext.Students.Add(student);
                dbContext.SaveChanges();
            }
        }
    }


    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public Standard Standard
        {
            get;
            set;
        }
    }

    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public ICollection<Student> Students { get; set; }
    }

    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
    }




}
