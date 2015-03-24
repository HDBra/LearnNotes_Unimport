using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfLearn.Utils
{
    public static class DbContextHelper
    {
        /// <summary>
        /// 将DbContext转换成更加原生的ObjectContext
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public static ObjectContext ConvertTo(this DbContext dbContext)
        {
            return (dbContext as IObjectContextAdapter).ObjectContext;
        }


        public static void Test()
        {
            using (var context = new SchoolDBEntities())
            {
                var l2EQuery = context.Students.Where(s => s.StudentID == 5);
                var student = l2EQuery.FirstOrDefault();
                Console.WriteLine(student==null?"":student.StudentName);
            }

            using (var context = new SchoolDBEntities())
            {
                context.Configuration.AutoDetectChangesEnabled = true;
                var studentList = context.Students.ToList<Student>();

                //Perform create operation
                context.Students.Add(new Student() { StudentName = "New Student" });

                //Perform Update operation
                Student studentToUpdate = studentList.Where(s => s.StudentName == "student1").FirstOrDefault<Student>();
                studentToUpdate.StudentName = "Edited student1";

                //Perform delete operation
                context.Students.Remove(studentList.ElementAt<Student>(0));

                //Execute Inser, Update & Delete queries in the database
                context.SaveChanges();

            }
        }
    }
}
