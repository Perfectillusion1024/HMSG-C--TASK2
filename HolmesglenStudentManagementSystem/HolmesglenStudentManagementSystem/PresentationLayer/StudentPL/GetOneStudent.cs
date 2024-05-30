using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class GetOneStudent : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Getting a student");
            Console.Write("Student ID: ");
            var id = Console.ReadLine();

            var studentBLL = new StudentBLL();
            var student = studentBLL.GetOne(id);
            if(student == null)
            {
                Console.WriteLine($"Student({id}) does not exist");
            }
            else
            {
                Console.WriteLine($"{student.Id}\t{student.FirstName}\t{student.LastName}\t{student.Email}");
            }
            
        }
    }
}
