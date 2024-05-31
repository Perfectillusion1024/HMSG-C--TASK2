using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class SubjectDAL
    {
        private SQLiteConnection _connection;

        public SubjectDAL(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
        }

        public void CreateSubject(Subject subject)
        {
            string query = "INSERT INTO Subject (Title) VALUES (@Title)";
            using (var command = new SQLiteCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Title", subject.Title);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public Subject GetSubject(int subjectId)
        {
            string query = "SELECT * FROM Subject WHERE SubjectID = @SubjectID";
            using (var command = new SQLiteCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@SubjectID", subjectId);
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var subject = new Subject
                        {
                            SubjectID = reader.GetInt32(0),
                            Title = reader.GetString(1)
                        };
                        _connection.Close();
                        return subject;
                    }
                }
                _connection.Close();
            }
            return null;
        }

        public void UpdateSubject(Subject subject)
        {
            string query = "UPDATE Subject SET Title = @Title WHERE SubjectID = @SubjectID";
            using (var command = new SQLiteCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Title", subject.Title);
                command.Parameters.AddWithValue("@SubjectID", subject.SubjectID);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void DeleteSubject(int subjectId)
        {
            string query = "DELETE FROM Subject WHERE SubjectID = @SubjectID";
            using (var command = new SQLiteCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@SubjectID", subjectId);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}