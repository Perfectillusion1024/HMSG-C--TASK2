using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class DeleteStudent : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Deleting a student");
            Console.Write("Student ID: ");
            var id = Console.ReadLine();

            var studentBLL = new StudentBLL();
            var result = studentBLL.Delete(id);
            if (result == false)
            {
                Console.WriteLine($"Delete student unsuccessful");
            }
            else
            {
                Console.WriteLine($"Delete student successful");
            }
        }
    }
}
