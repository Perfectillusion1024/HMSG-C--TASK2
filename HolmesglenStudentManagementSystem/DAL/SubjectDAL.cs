using HolmesglenStudentManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace HolmesglenStudentManagementSystem.DAL
{
    public class SubjectDAL
    {
        private string connectionString = @"Data Source=/Users/wiley/Library/CloudStorage/OneDrive-HolmesglenInstitute/C#/AssessmentTask2/Project2/HolmesglenStudentManagementSystem/HolmesglenStudentManagementSystem.db;";

        public void CreateSubject(Subject subject)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand(
                    "INSERT INTO Subject (Title, NumberOfSessions, HourPerSession) VALUES (@Title, @NumberOfSessions, @HourPerSession)",
                    connection);
                command.Parameters.AddWithValue("@Title", subject.Title);
                command.Parameters.AddWithValue("@NumberOfSessions", subject.NumberOfSessions);
                command.Parameters.AddWithValue("@HourPerSession", subject.HourPerSession);
                command.ExecuteNonQuery();
            }
        }

        public Subject ReadSubject(int subjectId)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand("SELECT * FROM Subject WHERE SubjectID = @SubjectID", connection);
                command.Parameters.AddWithValue("@SubjectID", subjectId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Subject
                        {
                            SubjectID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            NumberOfSessions = reader.GetInt32(2),
                            HourPerSession = reader.GetDouble(3)
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public List<Subject> ReadAllSubjects()
        {
            var subjects = new List<Subject>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand("SELECT * FROM Subject", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject
                        {
                            SubjectID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            NumberOfSessions = reader.GetInt32(2),
                            HourPerSession = reader.GetDouble(3)
                        });
                    }
                }
            }
            return subjects;
        }

        public void UpdateSubject(Subject subject)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand(
                    "UPDATE Subject SET Title = @Title, NumberOfSessions = @NumberOfSessions, HourPerSession = @HourPerSession WHERE SubjectID = @SubjectID",
                    connection);
                command.Parameters.AddWithValue("@Title", subject.Title);
                command.Parameters.AddWithValue("@NumberOfSessions", subject.NumberOfSessions);
                command.Parameters.AddWithValue("@HourPerSession", subject.HourPerSession);
                command.Parameters.AddWithValue("@SubjectID", subject.SubjectID);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteSubject(int subjectId)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand("DELETE FROM Subject WHERE SubjectID = @SubjectID", connection);
                command.Parameters.AddWithValue("@SubjectID", subjectId);
                command.ExecuteNonQuery();
            }
        }
    }
}