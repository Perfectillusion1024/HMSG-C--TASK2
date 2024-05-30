using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    public class Student
    {
        public string Id;
        public string FirstName;
        public string LastName;
        public string Email;

        public Student()
        {
            Id = "";
            FirstName = "";
            LastName = "";
            Email = "";
        }

        public Student(string id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
