using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class EnrollmentDAL
    {
        private SQLiteConnection _connection;

        public EnrollmentDAL(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
        }

        public void CreateEnrollment(Enrollment enrollment)
        {
            string query = "INSERT INTO Enrollment (StudentID, SubjectID) VALUES (@StudentID, @SubjectID)";
            using (var command = new SQLiteCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@StudentID", enrollment.StudentID);
                command.Parameters.AddWithValue("@SubjectID", enrollment.SubjectID);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public Enrollment GetEnrollment(int enrollmentId)
        {
            string query = "SELECT * FROM Enrollment WHERE EnrollmentID = @EnrollmentID";
            using (var command = new SQLiteCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@EnrollmentID", enrollmentId);
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var enrollment = new Enrollment
                        {
                            EnrollmentID = reader.GetInt32(0),
                            StudentID = reader.GetInt32(1),
                            SubjectID = reader.GetInt32(2)
                        };
                        _connection.Close();
                        return enrollment;
                    }
                }
                _connection.Close();
            }
            return null;
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            string query = "UPDATE Enrollment SET StudentID = @StudentID, SubjectID = @SubjectID WHERE EnrollmentID = @EnrollmentID";
            using (var command = new SQLiteCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@StudentID", enrollment.StudentID);
                command.Parameters.AddWithValue("@SubjectID", enrollment.SubjectID);
                command.Parameters.AddWithValue("@EnrollmentID", enrollment.EnrollmentID);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void DeleteEnrollment(int enrollmentId)
        {
            string query = "DELETE FROM Enrollment WHERE EnrollmentID = @EnrollmentID";
            using (var command = new SQLiteCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@EnrollmentID", enrollmentId);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}