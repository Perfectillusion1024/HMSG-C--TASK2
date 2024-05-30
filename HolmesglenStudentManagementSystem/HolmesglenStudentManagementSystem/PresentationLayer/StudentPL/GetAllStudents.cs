using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class GetAllStudents : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Getting all students");

            var studentBLL = new StudentBLL();
            var result = studentBLL.GetAll();
            if (result.Count == 0)
            {
                Console.WriteLine("table is empty");
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Id}\t{item.FirstName}\t{item.LastName}\t{item.Email}");
                }
            }
        }
    }
}
