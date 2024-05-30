using System;
using HolmesglenStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class CreateStudent : PLBase
    {
        public override void Run()
        {
            var student = new Student();
            Console.WriteLine("Creating a new student");
            Console.Write("Enter ID: ");
            student.Id = Console.ReadLine();
            Console.Write("Enter First Name: ");
            student.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            student.LastName = Console.ReadLine();
            Console.Write("Enter Email: ");
            student.Email = Console.ReadLine();

            var studentBLL = new StudentBLL();
            var result = studentBLL.Create(student);

            if (result == false)
            {
                Console.WriteLine($"Create new student unsuccessful");
            }
            else
            {
                Console.WriteLine($"Create new student successful");
            }
        }
    }
}
