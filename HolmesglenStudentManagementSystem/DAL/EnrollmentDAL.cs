using HolmesglenStudentManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace HolmesglenStudentManagementSystem.DAL
{
    public class EnrollmentDAL
    {
        private string connectionString = @"Data Source=/Users/wiley/Library/CloudStorage/OneDrive-HolmesglenInstitute/C#/AssessmentTask2/Project2/HolmesglenStudentManagementSystem/HolmesglenStudentManagementSystem.db;";

        public void CreateEnrollment(Enrollment enrollment)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand(
                    "INSERT INTO Enrollment (StudentID_FK, SubjectID_FK) VALUES (@StudentID_FK, @SubjectID_FK)",
                    connection);
                command.Parameters.AddWithValue("@StudentID_FK", enrollment.StudentID_FK);
                command.Parameters.AddWithValue("@SubjectID_FK", enrollment.SubjectID_FK);
                command.ExecuteNonQuery();
            }
        }

        public Enrollment ReadEnrollment(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand("SELECT * FROM Enrollment WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Enrollment
                        {
                            ID = reader.GetInt32(0),
                            StudentID_FK = reader.GetInt32(1),
                            SubjectID_FK = reader.GetInt32(2)
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public List<Enrollment> ReadAllEnrollments()
        {
            var enrollments = new List<Enrollment>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand("SELECT * FROM Enrollment", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        enrollments.Add(new Enrollment
                        {
                            ID = reader.GetInt32(0),
                            StudentID_FK = reader.GetInt32(1),
                            SubjectID_FK = reader.GetInt32(2)
                        });
                    }
                }
            }
            return enrollments;
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand(
                    "UPDATE Enrollment SET StudentID_FK = @StudentID_FK, SubjectID_FK = @SubjectID_FK WHERE ID = @ID",
                    connection);
                command.Parameters.AddWithValue("@StudentID_FK", enrollment.StudentID_FK);
                command.Parameters.AddWithValue("@SubjectID_FK", enrollment.SubjectID_FK);
                command.Parameters.AddWithValue("@ID", enrollment.ID);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEnrollment(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand("DELETE FROM Enrollment WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }
        }
    }
}