using System;
using HolmesglenStudentManagementSystem.BLL;
using HolmesglenStudentManagementSystem.Models;

namespace HolmesglenStudentManagementSystem.PL
{
    public class ConsoleInterface
    {
        private StudentBLL studentBLL = new StudentBLL();

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Student");
                Console.WriteLine("3. View All Students");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1":
                            AddStudent();
                            break;
                        case "2":
                            ViewStudent();
                            break;
                        case "3":
                            ViewAllStudents();
                            break;
                        case "4":
                            UpdateStudent();
                            break;
                        case "5":
                            DeleteStudent();
                            break;
                        case "6":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void AddStudent()
        {
            var student = new Student();

            Console.Write("Enter first name: ");
            student.FirstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            student.LastName = Console.ReadLine();

            Console.Write("Enter email address: ");
            student.EmailAddress = Console.ReadLine();

            Console.Write("Enter age: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                student.Age = age;
            }
            else
            {
                Console.WriteLine("Invalid age. Operation aborted.");
                return;
            }

            student.EnrolmentDate = DateTime.Now;

            studentBLL.CreateStudent(student);
            Console.WriteLine("Student added successfully.");
        }

        private void ViewStudent()
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var student = studentBLL.GetStudentById(studentId);
                if (student != null)
                {
                    Console.WriteLine($"ID: {student.StudentID}");
                    Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
                    Console.WriteLine($"Email: {student.EmailAddress}");
                    Console.WriteLine($"Age: {student.Age}");
                    Console.WriteLine($"Enrolment Date: {student.EnrolmentDate}");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        private void ViewAllStudents()
        {
            var students = studentBLL.GetAllStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.StudentID} - Name: {student.FirstName} {student.LastName}");
            }
        }

        private void UpdateStudent()
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var student = studentBLL.GetStudentById(studentId);
                if (student != null)
                {
                    Console.Write("Enter new first name (leave empty to keep current): ");
                    var firstName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(firstName))
                    {
                        student.FirstName = firstName;
                    }

                    Console.Write("Enter new last name (leave empty to keep current): ");
                    var lastName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(lastName))
                    {
                        student.LastName = lastName;
                    }

                    Console.Write("Enter new email address (leave empty to keep current): ");
                    var email = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        student.EmailAddress = email;
                    }

                    Console.Write("Enter new age (leave empty to keep current): ");
                    var ageInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(ageInput) && int.TryParse(ageInput, out int age))
                    {
                        student.Age = age;
                    }

                    studentBLL.UpdateStudent(student);
                    Console.WriteLine("Student updated successfully.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        private void DeleteStudent()
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                studentBLL.DeleteStudent(studentId);
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }
    }
}