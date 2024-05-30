using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class StudentDAL
    {        
        private SqliteConnection Connection;

        public StudentDAL(SqliteConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }
        // create
        public void Create(Student student)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Student
                (StudentID, FirstName, LastName, Email)
                VALUES(@a, @b, @c, @d)
            ";

            command.Parameters.AddWithValue("a", student.Id);
            command.Parameters.AddWithValue("b", student.FirstName);
            command.Parameters.AddWithValue("c", student.LastName);
            command.Parameters.AddWithValue("d", student.Email);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        public Student Read(string id)
        {
            Student student = null;
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT StudentID, FirstName, LastName, Email
                FROM Student
                WHERE StudentId = @a
            ";
            command.Parameters.AddWithValue("a", id);


            // execute the query
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var studentId = reader.GetString(0);
                var studentFName = reader.GetString(1);
                var studentLName = reader.GetString(2);
                var studentEmail = reader.GetString(3);
                student = new Student(studentId, studentFName, studentLName, studentEmail);
            } // else student = null

            Connection.Close();

            return student;
        }

        // read all
        public List<Student> ReadAll()
        {
            var students = new List<Student>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT StudentID, FirstName, LastName, Email
                FROM Student
            ";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var studentId = reader.GetString(0);
                var studentFName = reader.GetString(1);
                var studentLName = reader.GetString(2);
                var studentEmail = reader.GetString(3);
                students.Add(new Student(studentId, studentFName, studentLName, studentEmail));
            }
            Connection.Close();
            return students;
        }

        public void Update(Student student)
        {
            // challenge yourself
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                UPDATE Student
                SET FirstName = @a,
                    LastName = @b,
                    Email = @c
                WHERE StudentID = @d
            ";
            command.Parameters.AddWithValue("a", student.FirstName);
            command.Parameters.AddWithValue("b", student.LastName);
            command.Parameters.AddWithValue("c", student.Email);
            command.Parameters.AddWithValue("d", student.Id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        public void Delete(string id)
        {
            // challenge yourself
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                DELETE FROM Student
                WHERE StudentID = @a
            ";
            command.Parameters.AddWithValue("a", id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }
    }
}
