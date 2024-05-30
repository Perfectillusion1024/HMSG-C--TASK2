using HolmesglenStudentManagementSystem.PresentationLayer;
using HolmesglenStudentManagementSystem.DataAccessLayer;
using System;
using HolmesglenStudentManagementSystem.PresentationLayer.StudentPL;

namespace HolmesglenStudentManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (new GetAllStudents()).Run();
            // uncomment the code below for testing
            //(new GetOneStudent()).Run();
            //(new CreateStudent()).Run();
            //(new UpdateStudent()).Run();
            //(new DeleteStudent()).Run();
        }

    }
}
