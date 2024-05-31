using System;
using Microsoft.Data.Sqlite;

namespace StudentManagementSystem
{
    class Program
    {
        static string connectionString = @"Data Source=student_management.db;";

        static void Main(string[] args)
        {
            InitializeDatabase();

            Console.WriteLine("Welcome to Student Management System");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Add Subject");
            Console.WriteLine("4. Enroll Student");
            Console.WriteLine("5. View Enrollment");
            Console.WriteLine("6. Update Enrollment");
            Console.WriteLine("7. Delete Enrollment");
            Console.WriteLine("8. Exit");

            while (true)
            {
                Console.Write("\nEnter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        ViewStudents();
                        break;

                    case 3:
                        AddSubject();
                        break;
                    case 4:
                        EnrollStudent();
                        break;
                    case 5:
                        ViewEnrollment();
                        break;
                    case 6:
                        UpdateEnrollment();
                        break;
                    case 7:
                        DeleteEnrollment();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void InitializeDatabase()
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string createTableStudent = "CREATE TABLE IF NOT EXISTS Student (StudentId INTEGER PRIMARY KEY, StudentName TEXT)";
                string createTableSubject = "CREATE TABLE IF NOT EXISTS Subject (SubjectId INTEGER PRIMARY KEY, Subject TEXT)";
                string createTableEnrollment = "CREATE TABLE IF NOT EXISTS Enrollment (EnId INTEGER PRIMARY KEY, StudentId_FK INTEGER, SubjectId_FK INTEGER, Grade TEXT, EnrollmentDate TEXT, FOREIGN KEY(StudentId_FK) REFERENCES Student(StudentId), FOREIGN KEY(SubjectId_FK) REFERENCES Subject(SubjectId))";

                SqliteCommand command1 = new SqliteCommand(createTableStudent, connection);
                SqliteCommand command2 = new SqliteCommand(createTableSubject, connection);
                SqliteCommand command3 = new SqliteCommand(createTableEnrollment, connection);

                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = $"INSERT INTO Student (StudentName) VALUES ('{studentName}')";

                SqliteCommand command = new SqliteCommand(insertQuery, connection);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Student added successfully.");
                else
                    Console.WriteLine("Failed to add student.");
            }
        }

        static void ViewStudents()
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Student";

                SqliteCommand command = new SqliteCommand(selectQuery, connection);
                SqliteDataReader reader = command.ExecuteReader();

                Console.WriteLine("\nStudents:");
                Console.WriteLine("---------");
                Console.WriteLine("Student ID\tStudent Name");
                Console.WriteLine("-------------------------");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["StudentId"]}\t\t{reader["StudentName"]}");
                }

                reader.Close();
            }
        }

        static void AddSubject()
        {
            Console.Write("Enter subject name: ");
            string subjectName = Console.ReadLine();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = $"INSERT INTO Subject (Subject) VALUES ('{subjectName}')";

                SqliteCommand command = new SqliteCommand(insertQuery, connection);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Subject added successfully.");
                else
                    Console.WriteLine("Failed to add subject.");
            }
        }

        static void EnrollStudent()
        {
            Console.Write("Enter Student ID: ");
            int studentId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Subject ID: ");
            int subjectId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Grade: ");
            string grade = Console.ReadLine();

            Console.Write("Enter Enrollment Date (dd-mm-yyyy): ");
            string enrollmentDate = Console.ReadLine();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = $"INSERT INTO Enrollment (StudentId_FK, SubjectId_FK, Grade, EnrollmentDate) VALUES ({studentId}, {subjectId}, '{grade}', '{enrollmentDate}')";

                SqliteCommand command = new SqliteCommand(insertQuery, connection);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Student enrolled successfully.");
                else
                    Console.WriteLine("Failed to enroll student.");
            }
        }

        static void ViewEnrollment()
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Student.StudentName, Subject.Subject, Enrollment.Grade, Enrollment.EnrollmentDate FROM Enrollment INNER JOIN Student ON Enrollment.StudentId_FK = Student.StudentId INNER JOIN Subject ON Enrollment.SubjectId_FK = Subject.SubjectId";

                SqliteCommand command = new SqliteCommand(selectQuery, connection);
                SqliteDataReader reader = command.ExecuteReader();

                Console.WriteLine("\nEnrollments:");
                Console.WriteLine("-------------");
                Console.WriteLine("Student Name\tSubject\tGrade\tEnrollment Date");
                Console.WriteLine("----------------------------------------------");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["StudentName"]}\t{reader["Subject"]}\t{reader["Grade"]}\t{reader["EnrollmentDate"]}");
                }

                reader.Close();
            }
        }

        static void UpdateEnrollment()
        {
            Console.Write("Enter Enrollment ID to update: ");
            int enrollmentId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new Grade: ");
            string newGrade = Console.ReadLine();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string updateQuery = $"UPDATE Enrollment SET Grade = '{newGrade}' WHERE EnId = {enrollmentId}";

                SqliteCommand command = new SqliteCommand(updateQuery, connection);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Enrollment updated successfully.");
                else
                    Console.WriteLine("Failed to update enrollment.");
            }
        }

        static void DeleteEnrollment()
        {
            Console.Write("Enter Enrollment ID to delete: ");
            int enrollmentId = Convert.ToInt32(Console.ReadLine());

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = $"DELETE FROM Enrollment WHERE EnId = {enrollmentId}";

                SqliteCommand command = new SqliteCommand(deleteQuery, connection);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Enrollment deleted successfully.");
                else
                    Console.WriteLine("Failed to delete enrollment.");
            }
        }
    }
}
