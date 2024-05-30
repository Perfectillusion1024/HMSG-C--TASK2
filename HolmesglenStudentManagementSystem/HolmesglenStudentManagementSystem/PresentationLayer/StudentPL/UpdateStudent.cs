using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class UpdateStudent : PLBase
    {
        public override void Run()
        {
            var student = new Student();
            Console.WriteLine("Updating a new student");
            Console.Write("Enter ID: ");
            student.Id = Console.ReadLine();
            Console.Write("Enter First Name: ");
            student.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            student.LastName = Console.ReadLine();
            Console.Write("Enter Email: ");
            student.Email = Console.ReadLine();

            var studentBLL = new StudentBLL();
            var result = studentBLL.Update(student);

            if (result == false)
            {
                Console.WriteLine($"Update student unsuccessful");
            }
            else
            {
                Console.WriteLine($"Update student successful");
            }
        }
    }
}
